using UnityEngine;
using System.Collections;
public class enemy_shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float rate_of_fire = 2f;
    private GameObject player;
    public int health = 100;
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer
    private Color originalColor;
    public float moveSpeed = 3f;   // Speed at which the enemy moves towards the player
    public float stopRadius = 2f;
    public Rigidbody2D rb;
    void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        // If the distance is greater than the stop radius, move the enemy
        if (distanceToPlayer > stopRadius)
        {
            // Move the enemy towards the player by setting the Rigidbody2D velocity
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            // Stop the enemy's movement when it is within the stop radius
            rb.linearVelocity = Vector2.zero;
        }
    }
    private IEnumerator RevertColorBack()
    {
        // Wait for 0.5 seconds (adjust this value as needed)
        yield return new WaitForSeconds(7f);

        // Revert the color back to the original color
        spriteRenderer.color = originalColor;
    }
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        spriteRenderer.color = Color.red;

        // Optionally, start a coroutine to revert the color back after a short delay
        StartCoroutine(RevertColorBack());
        if (health <= 0)
        {
            Die();
        }
    }

    // Handle enemy death
    void Die()
    {
        // For now, just destroy the enemy when it dies
        Destroy(gameObject);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Store the original color (assuming the enemy has a sprite)
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance< 10)
        {
            timer += Time.deltaTime;
            if (timer >= rate_of_fire)
            {
                timer = 0;
                shoot();
            }
        }
 

    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
