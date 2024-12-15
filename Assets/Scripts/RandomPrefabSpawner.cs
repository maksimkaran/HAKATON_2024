using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    // References to the 3 specific prefabs you want to spawn
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    // The area where the objects can spawn (min and max coordinates for x and y)
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    // Time interval between spawns
    public float spawnInterval = 2f;

    void Start()
    {
        // Start the spawning at regular intervals
        InvokeRepeating("SpawnRandomPrefab", 0f, spawnInterval);
    }

    void SpawnRandomPrefab()
    {
        // Randomly select one of the three prefabs
        GameObject prefabToSpawn = ChooseRandomPrefab();

        // Choose a random position within the spawn area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Instantiate the selected prefab at the random position
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }

    // Choose one of the three prefabs randomly
    GameObject ChooseRandomPrefab()
    {
        int randomPrefabIndex = Random.Range(0, 3); // 0, 1, or 2

        // Return the corresponding prefab based on the random index
        switch (randomPrefabIndex)
        {
            case 0:
                return prefab1;
            case 1:
                return prefab2;
            case 2:
                return prefab3;
            default:
                return prefab1; // Default fallback
        }
    }
}
