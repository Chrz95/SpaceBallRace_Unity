using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SizeDecreaser : MonoBehaviour {

		void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.CompareTag ("Player"))
        {	
			collider.transform.localScale = (collider.transform.localScale)/2 ; 
			collider.GetComponent<TrailRenderer>().startWidth = collider.GetComponent<TrailRenderer>().startWidth/2 ;
			Destroy(gameObject); //Destroys canceller
		}

	}
}
