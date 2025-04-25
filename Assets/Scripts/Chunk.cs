using System.Collections.Generic;
using UnityEngine;
//yeni bir ekleme
public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject Fence;
    [SerializeField] Transform parent;
    [SerializeField ] float [] lanes= {-2.5f,0,2.5f};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFence();
    }
    void SpawnFence() 
    {
        List<int> availableLanes = new List<int> { 0, 1, 2 };
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
           
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectedLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(Fence, spawnPosition, Quaternion.identity, this.transform);
        }
    }

}
