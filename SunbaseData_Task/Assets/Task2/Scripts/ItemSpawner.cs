using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject circlePrefab;

    [SerializeField] int minCount;

    [SerializeField] List<Transform> spawnPoints;

    Dictionary<Transform, bool> spawnPointDict = new Dictionary<Transform, bool>();
    List<GameObject> itemList = new List<GameObject>();

    private void OnEnable()
    {
        EventHandler.OnRestartEvent += Restart;
    }

    private void OnDisable()
    {
        EventHandler.OnRestartEvent -= Restart;
    }

    private void Start()
    {
        foreach(Transform transform in spawnPoints)
        {
            spawnPointDict.Add(transform, false);
        }
        SpawnItem();
    }

    void SpawnItem()
    {
        int randCount = Random.Range(minCount, spawnPoints.Count);
        for (int i = 0; i < randCount; i++)
        {
            int randIndex = Random.Range(0, spawnPoints.Count);

            while (spawnPointDict[spawnPoints[randIndex]] == true)
            {
                randIndex = Random.Range(0, spawnPoints.Count);
            }
            GameObject go = Instantiate(circlePrefab, spawnPoints[randIndex].position, Quaternion.identity);
            spawnPointDict[spawnPoints[randIndex]] = true;

            itemList.Add(go);
        }
    }

    private void Restart()
    {
        foreach (Transform transform in spawnPoints)
        {
            spawnPointDict[transform] = false;
        }
        foreach(var go in itemList)
        {
            Destroy(go);
        }
        SpawnItem();
    }
}
