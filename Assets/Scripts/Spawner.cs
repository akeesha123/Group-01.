using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject bombPrefab;

    public float spawnInterval = 1f;
    public float xRange = 8f;

    [Range(0f, 1f)]
    public float bombChance = 0.25f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-xRange, xRange);

        Vector3 spawnPos = new Vector3(
            randomX,
            transform.position.y,
            0f
        );

        GameObject toSpawn = fruitPrefab;

        if (bombPrefab != null && Random.value < bombChance)
        {
            toSpawn = bombPrefab;
        }

        Instantiate(toSpawn, spawnPos, Quaternion.identity);
    }
}