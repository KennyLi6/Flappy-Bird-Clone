using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private GameObject _pipesPrefab;
    [SerializeField] private GameObject _spawnLocation;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private const int SCENE_TO_RELOAD = 0;

    private float _timeUntilSpawn = 0f;

    private void Start()
    {
        _gameInput.OnRestartAction += GameInput_OnRestartAction;
    }

    private void GameInput_OnRestartAction(object sender, System.EventArgs e)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SCENE_TO_RELOAD);
    }
    // TODO: Event listener for Player Collision Event

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

    private void OnDisable()
    {
        _gameInput.OnRestartAction -= GameInput_OnRestartAction;
    }

}
