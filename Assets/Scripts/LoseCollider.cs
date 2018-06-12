using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager _levelManager;
    private PlayerManager _playerManager;
    private Ball _ball;

    void OnTriggerEnter2D (Collider2D trigger)
    {
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _playerManager = GameObject.FindObjectOfType<PlayerManager>();
        _ball = GameObject.FindObjectOfType<Ball>();

        if (_playerManager.GetLives() <= 1)
        {
            _levelManager.LoadLevel("Lose Screen");
        }
        else
        {
            _playerManager.SetLives(-1);
            _ball.SetOnDefault();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
