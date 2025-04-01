using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 10f; // Damage dealt to the player
    public float lifetime = 2f; // Time before the bullet is destroyed

    void Start()
    {
        // Destroy the bullet after a set lifetime
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet hits the player
        if (other.CompareTag("Player"))
        {
            // Deal damage to the player
            SideScrollerPlayer player = other.GetComponent<SideScrollerPlayer>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Destroy the bullet if it hits an obstacle
            Destroy(gameObject);
        }
    }
}