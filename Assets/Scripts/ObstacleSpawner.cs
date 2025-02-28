using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnTime = 1f;

    int obstaclesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());   
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
            obstaclesSpawned++;
        }
    }
}
