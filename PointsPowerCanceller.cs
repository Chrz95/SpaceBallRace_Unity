using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PointsPowerCanceller : MonoBehaviour {

    private Text bonuslabel, bonuslabel1;

    private void Start()
    {
        bonuslabel = GameObject.Find("bonus").GetComponent<Text>();
        bonuslabel1 = GameObject.Find("LivesDecreased").GetComponent<Text>();
    }

    // Use this for initialization
    void OnTriggerEnter (Collider collider)
	{	
		if (collider.gameObject.CompareTag ("Player"))
        {		
			bonuslabel.text = "";	    		
			bonuslabel1.text = "";	
			collider.gameObject.GetComponent<Points>().points_multiplier = 1 ;
			Destroy(gameObject) ; //Destroys Canceller
		}

	}
}
