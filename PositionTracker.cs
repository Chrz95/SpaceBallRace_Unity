using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionTracker : MonoBehaviour {

	private GameObject Player ;  
	public int myPlace ; 
    public static int PlayerPlace ; 
	
	void Start ()
	{
		myPlace = 1 ;
        PlayerPlace = 1; 
        Player = GameObject.Find("Sphere_Player");
	}

	// Update is called once per frame
	void Update ()
	{		
		myPlace = 1 ; 
			
		foreach (GameObject gb in AI_Generator.Players)  // Calculate each player position
		{
			if ((gb != null) && (this.gameObject != null))
            {
                if (gb.transform.GetChild(0).transform.localPosition.z > gameObject.transform.localPosition.z)
                {
                    myPlace++;                   
                }                
            }	          
		}

        if (gameObject.name == "Sphere_Player")
        {
            //Debug.Log("YES");
            PlayerPlace = myPlace;
        }

        if (this.gameObject.name != "Sphere_Player")
            gameObject.transform.parent.GetChild(1).gameObject.GetComponent<TMP_Text>().text = myPlace.ToString() ; // Update the respective text	
	}
}
