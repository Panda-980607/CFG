using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] prefabs; 
    public Transform[] spawnPoints;
    public Transform[] endPoints;

    private List<GameObject> spawnedPrefabs = new List<GameObject>();

    void Start()
    {
        SpawnOnce();
    }

    void SpawnOnce()
    {

        List<GameObject> prefabList = new List<GameObject>(prefabs);
        ShuffleList(prefabList);

        int spawnCount = Mathf.Min(spawnPoints.Length, prefabList.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawnedP = Instantiate(prefabList[i], spawnPoints[i].position, Quaternion.identity);
            spawnedPrefabs.Add(spawnedP);
        }
    }

    void ShuffleList(List<GameObject> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public List<GameObject> GetSpawnedPrefabs()
    {
        return spawnedPrefabs;
    }
}
