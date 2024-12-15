using UnityEngine;

public class player_shooting : MonoBehaviour
{
    public GameObject projectilePrefab;  // The projectile to be shot
    public float shootingForce = 10f;    // Force applied to the projectile

    // Update is called once per frame
    void Update()
    {
        // Check for shooting input (for example, pressing the spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile at the player's position and with the same rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply a force to the projectile to make it move
        rb.AddForce(transform.right * shootingForce, ForceMode2D.Impulse); // Assuming the player faces to the right
    }
}