using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour
{
    private PlayerManager _playerManager;
    private TimeManager _timeManager;

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            try
            {
                _playerManager = GameObject.FindObjectOfType<PlayerManager>();
                _timeManager = GameObject.FindObjectOfType<TimeManager>();

                _playerManager.SetScore((int)_timeManager.GetTime() * 10);
            }
            catch(Exception ex)
            {

            }
        }

        Brick.BreakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            try
            {
                _playerManager = GameObject.FindObjectOfType<PlayerManager>();
                _timeManager = GameObject.FindObjectOfType<TimeManager>();

                _playerManager.SetScore((int)_timeManager.GetTime() * 10);
            }
            catch (Exception ex)
            {

            }
        }

        Brick.BreakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
