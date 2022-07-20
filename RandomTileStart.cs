using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ; 

public class RandomTileStart : MonoBehaviour {

	public List<GameObject> GroundList = new List<GameObject>();
	private Transform BallTransform  ; 
	private bool CreatedNewTile ; 
	private GameObject Sphere ;
	private int choice ; 
	private GameObject RealGround ;
	
	// Use this for initialization
	void Start () 
	{		
		choice = UnityEngine.Random.Range(0,GroundList.Count - 1);
		Sphere = GameObject.Find("Sphere_Player") ;  
		CreatedNewTile = false ;	
		if (Sphere != null)
		{	
    		BallTransform = Sphere.GetComponent<Transform>();	
		}
	}

	void FixedUpdate () 
	{
		if (Sphere != null)
		{
    		if ((BallTransform.position.z + 1000 >= transform.position.z) && (CreatedNewTile == false))		
			{
				CreatedNewTile = true ;	
				Vector3 NewPos = new Vector3(transform.position.x - 0.5f,transform.position.y + 8.9f ,transform.position.z + 1500); // Normal then normal	
				Instantiate (GroundList[choice],NewPos,transform.rotation);				
			}		
		}			
	}		


}

