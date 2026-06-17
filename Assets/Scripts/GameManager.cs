using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private float timeBetweenSpawn = 2f;
    private float timeUntilSpawn;

    private void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            timeUntilSpawn = timeBetweenSpawn;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        Instantiate(pipesPrefab, spawnLocation.transform);
    }
}
