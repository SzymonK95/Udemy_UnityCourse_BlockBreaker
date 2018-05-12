﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector3;

	// Use this for initialization
	void Start ()
	{
	    paddle = GameObject.FindObjectOfType<Paddle>();
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

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.3f), Random.Range(0f,0.3f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }

    }
}
