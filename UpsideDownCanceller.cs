using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpsideDownCanceller : MonoBehaviour {

    public GameObject MainCamera; 

	void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.CompareTag ("Player"))
        {
            MainCamera.transform.Rotate(0,0,-180);//Power deactivation
	   		Destroy(gameObject); //Destroys canceller
		}
	}
}
