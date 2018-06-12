using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private static PlayerManager instatnce = null;

    private int _score;
    private int _lives;

    public Text LivesText;
    public Text ScoreText;

    void Awake()
    {
        if (instatnce != null)
        {
            Destroy(gameObject);
            print("Duplicate Player Manager self-destructing!");
        }
        else
        {
            instatnce = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _score = 0;
            _lives = 3;
        }

        try
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                ScoreText = GameObject.Find("Score").GetComponent<Text>();
                ScoreText.text = "Score: " + GetScore().ToString();

                LivesText = GameObject.Find("Lives").GetComponent<Text>();
                LivesText.text = "Lives: " + GetLives().ToString();
            }
        }
        catch(Exception ex)
        {
            
        }
    }

    public int GetLives()
    {
        return _lives;
    }

    public void SetLives(int valueToAdd)
    {
        _lives += valueToAdd;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int valueToAdd)
    {
        _score += valueToAdd;
    }
}
