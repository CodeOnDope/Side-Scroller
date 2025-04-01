using UnityEngine;

[CreateAssetMenu(fileName = "NewPickupData", menuName = "ScriptableObjects/PickupData", order = 2)]
public class PickupData : ScriptableObject
{
    public enum PickupType
    {
        Health,     // Restores health
        Ammo,       // Provides ammunition
        PowerUp,    // Temporary power-up (e.g., increased speed, damage)
        Special     // Special ability or collectible
    }

    [Header("Basic Info")]
    public string pickupName; // Name of the pickup
    public Sprite pickupSprite; // Sprite for the pickup
    public PickupType type; // Type of the pickup

    [Header("Pickup Effects")]
    public int healthRestoreAmount; // Amount of health restored (if type is Health)
    public int ammoAmount; // Amount of ammo provided (if type is Ammo)
    public float powerUpDuration; // Duration of the power-up effect (if type is PowerUp)
    public string specialAbilityName; // Name of the special ability (if type is Special)

    [Header("Pickup Behavior")]
    public bool autoCollect = false; // Whether the pickup is automatically collected when the player is near
    public float autoCollectRadius = 1.5f; // Radius for auto-collection (if autoCollect is true)
}