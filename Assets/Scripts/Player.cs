using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void GameOver();
    public delegate void Success();
    public event GameOver OnGameOver;
    public event Success OnSuccess;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            if (OnSuccess != null)
            {
                OnSuccess();
            }
        }
    }

    private void OnBecameInvisible()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
}
