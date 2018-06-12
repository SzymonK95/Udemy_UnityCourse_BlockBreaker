using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private LevelManager _levelManager;
    private PlayerManager _playerManager;
    private float targetTime;
    public Text targetTimeText;

    void Start()
    {
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _playerManager = GameObject.FindObjectOfType<PlayerManager>();
        targetTimeText = GameObject.Find("Time").GetComponent<Text>();
        targetTime = 200f;
    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        targetTimeText.text = "Time: " + ((int)targetTime).ToString();

        if (targetTime <= 0.0f)
        {
            if (_playerManager.GetLives() < 0)
            {
                Debug.Log("End of time");
                timerEnded();
            }
            else
            {
                targetTime += 60f;
                _playerManager.SetLives(-1);
            }
        }
    }

    void timerEnded()
    {
        _levelManager.LoadLevel("Lose Screen");
    }

    public float GetTime()
    {
        return targetTime;
    }
}
