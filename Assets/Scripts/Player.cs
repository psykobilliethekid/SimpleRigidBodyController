/*
 * Project: Simple Rigidbody Character Controller
 * Description: Rigidbody character controller constrained to the X and Y axis to move left and right as well as jump.
 * Tutorial Used: BMS Unity3D: Simple custom player controller 
 * Tutorial URI: http://youtu.be/jjFrpWdBZ6s
 * Completion Date: 09 May 2014
 */

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public float speed = 0.1f;
	public float jumpForce = 500f;
	private bool isJumping = true;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	 void Update () 
	{
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.position += transform.right * speed;


		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.position += -transform.right * speed;


		if(!isJumping)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				transform.rigidbody.AddForce(0, jumpForce, 0);
				isJumping = true;
			}
		}

	}

	private void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.name == "Floor")
			isJumping = false;
	}
}
