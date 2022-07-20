using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

	private Rigidbody rb ;
	public static float AsteroidSpeed ; 

	void Start()
	{
		rb = GetComponent<Rigidbody>();		 
		AsteroidSpeed = -800 ;  
		Destroy(this.gameObject,15);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 automovement = new Vector3 (0.0f, 0.0f,1); // Vertical Movement
		rb.AddForce (automovement * AsteroidSpeed); 
	}
}
