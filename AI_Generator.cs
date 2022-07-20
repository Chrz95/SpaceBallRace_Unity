using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Generator : MonoBehaviour {

	public GameObject AI_Player , Player , AI_Generator_New , Sphere ; 
	public static int NumOfEnemies = 10 ; 
	public static List<GameObject> Players = new List<GameObject>();
	public Text OpponentsText ; 
	
	// Use this for initialization
	void Start () 
	{
        Players.Add(Player);
        for (int i=0 ; i<NumOfEnemies ; i++)
		{
			Vector3 AI_Position_Old = new Vector3(Random.Range(this.gameObject.transform.position.x -45,this.gameObject.transform.position.x +40),transform.position.y, Random.Range(this.gameObject.transform.position.z - 10, this.gameObject.transform.position.z + 60));
			GameObject gb = Instantiate(AI_Player,AI_Position_Old,transform.rotation);
			Players.Add(gb);
		}			
	}
	void Update()	
	{
		// Opponent Counter
		int count = 0 ; 	
		foreach (GameObject gb in Players)  // Fill it with the remaining gameobjects
		{
			if (gb != null)	
				count++ ; 							
		}

        count--; // Remove player
		OpponentsText.text = count.ToString() ; 	
		
		if (count == 0) //Resurrect the AIs
		{	
			Vector3 AI_Gen_Position = new Vector3(Sphere.transform.position.x,Sphere.transform.position.y, Sphere.transform.position.z - 60);
			Instantiate(AI_Generator_New,AI_Gen_Position,transform.rotation);
			Destroy(gameObject);
		}

	}	
}
