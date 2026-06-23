using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pipesPrefab;
    [SerializeField] private GameObject _spawnLocation;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private float _timeUntilSpawn = 0f;

    private void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Debug.Log("Spawning pipes");
            _timeUntilSpawn = _timeBetweenSpawn;
            ObjectPoolManager.SpawnObject(_pipesPrefab, _spawnLocation.transform.position, Quaternion.identity);
        }
    }

}
