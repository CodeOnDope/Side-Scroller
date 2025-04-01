using UnityEngine;

public class SideScrollerPlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint; // The point where bullets are fired
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isGrounded;
    private float moveInput;
    private bool isFacingRight = true;
    private float nextFireTime;
    public float health = 100;
    public int ammo = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get player input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Handle shooting
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        // Update animations and sprite direction
        UpdateAnimation();
        UpdateSpriteDirection();
    }

    void FixedUpdate()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Move the player
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        if (animator != null)
        {
            animator.SetTrigger("Jump");
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is 0 for 2D

        // Calculate the direction from the fire point to the mouse position
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // Instantiate the bullet and set its velocity
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = direction * bulletSpeed;

        // Rotate the bullet to face the direction it's traveling
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void UpdateSpriteDirection()
    {
        // Flip the player sprite based on movement direction
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void UpdateAnimation()
    {
        if (animator == null) return;

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void TakeDamage(float damageAmount)
    {
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
        if (health <= 0)
        Destroy(gameObject);
        else
        health -= damageAmount;
       
        // Add health logic here
    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        Debug.Log($"Health restored by {amount}. Current health: {health}");
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
        Debug.Log($"Ammo increased by {amount}. Current ammo: {ammo}");
    }

    public void ActivatePowerUp(float duration)
    {
        Debug.Log($"Power-up activated for {duration} seconds!");
        // Implement power-up logic (e.g., increased speed, damage, etc.)
    }

    public void UnlockSpecialAbility(string abilityName)
    {
        Debug.Log($"Special ability unlocked: {abilityName}");
        // Implement logic for unlocking special abilities
    }
}