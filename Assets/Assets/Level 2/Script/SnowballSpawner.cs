using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject snowballPrefab;     // prefab bola yang akan di-spawn
    public float spawnInterval = 3f;      // jeda spawn dalam detik

    void Start()
    {
        InvokeRepeating(nameof(SpawnSnowball), 0f, spawnInterval);
    }

    void SpawnSnowball()
    {
        Instantiate(snowballPrefab, transform.position, Quaternion.identity);
    }
}
