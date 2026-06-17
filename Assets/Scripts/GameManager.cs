using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private float timeBetweenSpawn = 2f;
    private float timeUntilSpawn;
    private List<GameObject> pooledPipes;
    private int amountToPool = 3;

    private void Start()
    {
        pooledPipes = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(pipesPrefab);
            temp.SetActive(false);
            pooledPipes.Add(temp);
        }
    }

    private void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            timeUntilSpawn = timeBetweenSpawn;
        }
    }

}
