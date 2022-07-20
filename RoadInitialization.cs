using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInitialization : MonoBehaviour {

	public List<GameObject> StartGroundList = new List<GameObject>();
	private int choice ;
	// Use this for initialization
	void Start () {
		choice = UnityEngine.Random.Range(0,StartGroundList.Count - 1);
		Vector3 NewPos = new Vector3(0,0,700); 
		Instantiate (StartGroundList[choice],NewPos,transform.rotation);			
	}

}
