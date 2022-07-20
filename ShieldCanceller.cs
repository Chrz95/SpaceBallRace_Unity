using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCanceller : MonoBehaviour {

	void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.CompareTag ("Player"))
        {	
			collider.transform.GetChild(0).gameObject.SetActive(false);	
			collider.gameObject.layer = 13 ;		
	   		Destroy(gameObject); //Destroys canceller}
		}
	}

}


	