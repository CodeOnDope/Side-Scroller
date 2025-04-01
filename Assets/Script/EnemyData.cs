using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("Basic Info")]
    public string enemyName; // Name of the enemy
    public Sprite enemySprite; // Sprite for the enemy

    [Header("Stats")]
    public float maxHealth = 50f; // Maximum health of the enemy
    public float speed = 2f; // Movement speed of the enemy
    public float detectionRadius = 5f; // Radius within which the enemy detects the player
    public float attackRadius = 1.5f; // Radius within which the enemy attacks the player

    [Header("Attack Settings")]
    public float attackCooldown = 1.5f; // Time between attacks
    public float bulletSpeed = 5f; // Speed of bullets fired by the enemy
    public float damage = 10f; // Damage dealt to the player

    [Header("Pickup Settings")]
    public PickupData pickupToDrop; // The pickup the enemy will drop upon death
    public float dropChance = 0.5f; // Chance (0 to 1) of dropping the pickup
}