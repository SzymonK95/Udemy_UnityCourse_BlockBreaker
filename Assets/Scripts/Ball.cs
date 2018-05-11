using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector3;

	// Use this for initialization
	void Start ()
	{
	    paddleToBallVector3 = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!hasStarted)
	    {
	        this.transform.position = paddle.transform.position + paddleToBallVector3;

	        if (Input.GetMouseButton(0))
	        {
	            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
	            hasStarted = true;
	        }
	    }
	}
}
