using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour {

	// Use this for initialization
	public Transform ToFollow ; 

	void Start () {
		 transform.position = new Vector3(ToFollow.position.x + 4f , ToFollow.position.y + 6f , ToFollow.position.z);
	}
	
	// Update is called once per frame
	void Update () {	
		if (ToFollow!=null)
			transform.position = new Vector3(ToFollow.position.x + 4f, ToFollow.position.y + 6f , ToFollow.position.z);	
					
	}
}
