using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBehavior : MonoBehaviour {

	public float force ; 
	private AudioSource Pad ; 

	void Start()
	{
		Pad = GetComponent<AudioSource>();
		force = -4000; 
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Pad = GetComponent<AudioSource>();
			if (Pad!=null)
			{
				Pad.volume = 1f ; 
				Pad.Play();
			}
				
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * force);
		}	
		if (other.gameObject.tag == "AI_Player")
		{
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * force);
		}	
	}
}