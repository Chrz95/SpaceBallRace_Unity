using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		int SelfDestructionTime = 5 ;
		Destroy(this.gameObject,SelfDestructionTime);
	}
}
