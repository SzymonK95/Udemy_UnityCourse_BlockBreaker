using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float mousePositionBlocksX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 paddlePos = new Vector3(1f,this.transform.position.y,this.transform.position.z);

	    mousePositionBlocksX = Input.mousePosition.x / Screen.width * 16;

	    paddlePos.x = Mathf.Clamp(mousePositionBlocksX,0.5f,15.5f);

	    this.transform.position = paddlePos;
	}
}
