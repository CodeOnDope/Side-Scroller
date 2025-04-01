using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupData pickupData; // Reference to the PickupData ScriptableObject

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (pickupData != null && pickupData.pickupSprite != null)
        {
            spriteRenderer.sprite = pickupData.pickupSprite;
        }
    }

    void Update()
    {
        // Handle auto-collection behavior
        if (pickupData != null && pickupData.autoCollect)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, pickupData.autoCollectRadius, LayerMask.GetMask("Player"));
            if (playerCollider != null)
            {
                Collect(playerCollider.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    void Collect(GameObject player)
    {
        if (pickupData == null) return;

        // Handle pickup effects based on type
        SideScrollerPlayer playerScript = player.GetComponent<SideScrollerPlayer>();
        if (playerScript != null)
        {
            switch (pickupData.type)
            {
                case PickupData.PickupType.Health:
                    playerScript.RestoreHealth(pickupData.healthRestoreAmount);
                    break;

                case PickupData.PickupType.Ammo:
                    playerScript.AddAmmo(pickupData.ammoAmount);
                    break;

                case PickupData.PickupType.PowerUp:
                    playerScript.ActivatePowerUp(pickupData.powerUpDuration);
                    break;

                case PickupData.PickupType.Special:
                    playerScript.UnlockSpecialAbility(pickupData.specialAbilityName);
                    break;
            }
        }

        // Destroy the pickup after collection
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the auto-collect radius in the Scene view
        if (pickupData != null && pickupData.autoCollect)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, pickupData.autoCollectRadius);
        }
    }
}