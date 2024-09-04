using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; 
    public float spawnInterval = 0.5f; 
    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnRandomObject();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnRandomObject()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-6f, 6f), -6f);

        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], spawnPosition, Quaternion.identity);

        spawnedObject.AddComponent<ObjectMover>();
    }
}

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed = 2f; 

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if (transform.position.y >= 6f)
        {
            Destroy(gameObject);
        }
    }
}
