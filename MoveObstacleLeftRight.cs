using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleLeftRight : MonoBehaviour {

	public float speed ; 
	public static float MoveObstacleLeftRightSpeed ; 

	void Start ()
	{
		MoveObstacleLeftRightSpeed = 35 ; 
	}

	void FixedUpdate ()  
	{ 		
		if (transform.position.x > 40 )
		{
			speed = -MoveObstacleLeftRightSpeed ; 
		}
		else if (transform.position.x < -40)
		{
			speed =  MoveObstacleLeftRightSpeed ; 
		}

		transform.Translate(speed * Time.deltaTime,0,0);             
	}
}
