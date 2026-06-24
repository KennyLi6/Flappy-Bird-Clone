using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private PlayerCollisionManager _playerCollisionManager;
    [SerializeField] private GameObject _pipesPrefab;
    [SerializeField] private GameObject _spawnLocation;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private const int SCENE_TO_RELOAD = 0;

    private float _timeUntilSpawn = 0f;
    private int _playerScore = 0;

    private void Start()
    {
        _gameInput.OnRestartAction += GameInput_OnRestartAction;
        _playerCollisionManager.OnObstacleCollision += PlayerCollisionManager_OnObstacleCollision;
        _playerCollisionManager.OnScoreCollision += PlayerCollisionManager_OnScoreCollision;
    }

    private void PlayerCollisionManager_OnObstacleCollision(object sender, System.EventArgs e)
    {
        // End game
        // Currently works, but maybe better to set pipespeed to 0
        // and stop spawn timer counting to allow for player rb
        // to play out physics for game feel
        Time.timeScale = 0;
    }

    private void PlayerCollisionManager_OnScoreCollision(object sender, System.EventArgs e)
    {
        _playerScore ++;
        _scoreText.text = _playerScore.ToString();
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
            _timeUntilSpawn = _timeBetweenSpawn;
            ObjectPoolManager.SpawnObject(_pipesPrefab, _spawnLocation.transform.position, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        _playerScore = 0;
        _gameInput.OnRestartAction -= GameInput_OnRestartAction;
        _playerCollisionManager.OnObstacleCollision -= PlayerCollisionManager_OnObstacleCollision;
        _playerCollisionManager.OnScoreCollision -= PlayerCollisionManager_OnScoreCollision;
    }

}
