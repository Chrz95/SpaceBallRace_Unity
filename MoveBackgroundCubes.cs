using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundCubes : MonoBehaviour {

	public float speed ; 
	public float InitialHeight ; 

	void Start()
	{
		InitialHeight = transform.position.y ; 
		speed = 0 ; 
	}

	void FixedUpdate ()  
	{ 
		if (transform.position.y == InitialHeight )
		{
			if(UnityEngine.Random.Range(1,3)== 1)
			{
				speed = +300 ; 
			}			
			else speed = -300 ; 
		}
		else if (transform.position.y >=  InitialHeight + 1000 )
		{
			speed = -300 ; 
		}
		else if (transform.position.y <=  InitialHeight - 1000 )
		{
			speed = +300 ; 
		}

		transform.Translate(0,speed * Time.deltaTime,0);             
	}
}
