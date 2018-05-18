using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager _levelManager;
    private HealthManager _healthManager;
    private Ball _ball;

    void OnTriggerEnter2D (Collider2D trigger)
    {
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _healthManager = GameObject.FindObjectOfType<HealthManager>();
        _ball = GameObject.FindObjectOfType<Ball>();

        if (_healthManager.GetLives() <= 1)
        {
            _levelManager.LoadLevel("Lose Screen");
        }
        else
        {
            _healthManager.UpdateLives(-1);
            _ball.SetOnDefault();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
