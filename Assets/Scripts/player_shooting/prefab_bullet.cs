using UnityEngine;

public class prefab_bullet : MonoBehaviour
{
    public float lifetime = 5f;          // How long the projectile lives before being destroyed
    public int damage = 10;              // Damage dealt to enemies

    void Start()
    {
        // Destroy the projectile after a set amount of time to prevent it from lingering indefinitely
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the projectile collides with an enemy, deal damage and destroy the projectile
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy_shooting enemy = collision.gameObject.GetComponent<enemy_shooting>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}