using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private bool _gameStarted;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _gameStarted = false;
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.GetComponent<Player>().OnGameOver += RestartLevel;
            _player.GetComponent<Player>().OnSuccess += AdvanceToTheNewLevel;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Start") && !_gameStarted)
        {
            StartLevel();
        }

        if (Input.GetButtonDown("Restart"))
        {
            RestartLevel();
        }
    }

    private void StartLevel()
    {
        _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _gameStarted = true;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AdvanceToTheNewLevel()
    {
        var nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneUtility.GetScenePathByBuildIndex(nextLevelIndex).Length > 0)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("YOU WON THE GAME!");
        }
    }
    
    private void OnDisable()
    {
        if (_player != null)
        {
            _player.GetComponent<Player>().OnGameOver -= RestartLevel;
            _player.GetComponent<Player>().OnSuccess -= AdvanceToTheNewLevel;
        }
    }
}
