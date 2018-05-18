using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    public float minX, maxX;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.P))
	        autoPlay = !autoPlay;

        if (!autoPlay)
	    {
	        MoveWithMouse();
	    }
	    else
	    {
	        AutoPlay();
	    }
	}

    private void AutoPlay()
    {
        float ballPos = ball.transform.position.x;
        SetPaddlePosition(ballPos);
    }

    void MoveWithMouse()
    {
        float mousePositionBlocksX = Input.mousePosition.x / Screen.width * 16;
        SetPaddlePosition(mousePositionBlocksX);
    }

    void SetPaddlePosition(float xPosition)
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z)
        {
            x = Mathf.Clamp(xPosition, minX, maxX)
        };
        this.transform.position = paddlePos;
    }
}
