using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     [SerializeField] GameObject[] obstaclePrefabs;
     [SerializeField] float obstacleSpawnTime = 1f;
     [SerializeField] Transform ParentObstacle;
     [SerializeField] float spawnAreaSize = 5f; // Size of the spawn area

    int obstaclesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());

      IEnumerator SpawnObstacleRoutine() 
      {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spanwPosition = new Vector3(Random.Range(-spawnAreaSize, spawnAreaSize),transform.position.y,transform.position.z );
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spanwPosition, Random.rotation, ParentObstacle);
            obstaclesSpawned++;
          //  Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
      }
    }

}
