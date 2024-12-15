using UnityEngine;
using System.Collections;
public class enemy_spawner : MonoBehaviour
{
    // The enemy prefab to spawn
    public GameObject enemyPrefab;

    // The area where enemies can spawn (using min and max x and y values for a rectangular spawn zone)
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    // Sine wave properties to control spawn frequency
    public float spawnFrequency = 1f;   // How fast the sine wave oscillates (affects spawn rate)
    public float spawnAmount = 5f;      // Maximum number of enemies to spawn at once during peak
    public float spawnPhaseShift = 0f;  // To adjust the phase of the sine wave (when spawning happens)

    // Variables to control the spawn behavior
    private float nextSpawnTime = 0f;

    void Update()
    {
        // Get the sine value based on time, scaled by spawnFrequency to control how fast it oscillates
        float sineValue = Mathf.Sin(Time.time * spawnFrequency + spawnPhaseShift);

        // Map the sine value from the range (-1, 1) to (0, 1) to avoid negative spawn rates
        sineValue = (sineValue + 1f) / 2f;

        // Multiply the sine value by the spawnAmount to determine how many enemies to spawn
        int numberOfEnemiesToSpawn = Mathf.RoundToInt(sineValue * spawnAmount);

        // If it's time to spawn enemies based on the sine value
        if (Time.time > nextSpawnTime && numberOfEnemiesToSpawn > 0)
        {
            SpawnEnemies(numberOfEnemiesToSpawn);
            nextSpawnTime = Time.time + Random.Range(0.5f, 1.5f);  // Random delay to add variation
        }
    }

    void SpawnEnemies(int count)
    {
        // Spawn the specified number of enemies at random positions
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}