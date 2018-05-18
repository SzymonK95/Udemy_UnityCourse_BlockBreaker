using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private int _livesCount;
    public Text livesCountText;

	// Use this for initialization
	void Start ()
	{
	    _livesCount = 3;
	    livesCountText.text = "Lives: " + _livesCount.ToString();
	}

    // Update is called once per frame
    public void UpdateLives(int valueToAdd)
    {
        _livesCount += valueToAdd;
        livesCountText.text = "Lives: " + _livesCount.ToString();

    }

    public int GetLives()
    {
        return _livesCount;
    }
}
