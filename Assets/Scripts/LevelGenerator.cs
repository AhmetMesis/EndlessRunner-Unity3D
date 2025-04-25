using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject ChunkPrefab;
    [SerializeField] private int ChunkCount = 12;
    [SerializeField] private Transform ParentChunk;
    [SerializeField] private float ChunkSize = 10f;
    [SerializeField] private float MoveSpeed = 5f;

    private List<GameObject> Chunks = new List<GameObject>();

    private void Start()
    {
        SpawnChunks();
    }

    void Update()
    {
        MoveChunks();
       
    }

    private void MoveChunks()
    {
        for (int i = 0; i < Chunks.Count; i++)
        {
            GameObject chunk = Chunks[i];
            chunk.transform.Translate(-Vector3.forward * (MoveSpeed * Time.deltaTime)); // Daha güvenli yön
            if(chunk.transform.position.z <= Camera.main.transform.position.z - ChunkSize){
            Chunks.Remove(chunk);
            Destroy(chunk);

            SecSpawn();
            }
        }
    }

    private void SecSpawn(){
        Vector3 spawnPosition = new Vector3(0, 0, Chunks[Chunks.Count - 1].transform.position.z + ChunkSize);
        GameObject chunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity, ParentChunk);
        Chunks.Add(chunk);
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < ChunkCount; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * ChunkSize);
            GameObject chunk = Instantiate(ChunkPrefab, spawnPosition, Quaternion.identity, ParentChunk);
            Chunks.Add(chunk); // Doğru ekleme yöntemi
        }
    }
}
