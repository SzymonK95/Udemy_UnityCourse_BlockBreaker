using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Paddle : MonoBehaviour
{
    public float minX, maxX;
    public float speed = 0.1F;

    private Ball ball;

    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[PlayerPrefs.GetInt("sprite")];
    }
	
	// Update is called once per frame
	void Update ()
	{
        print("sprites: " + sprites.Length);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            SetPaddlePosition(-touchDeltaPosition.x * speed);
        }
	    else
	    {
            MoveWithMouse();
        }
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
