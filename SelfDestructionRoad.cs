using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructionRoad : MonoBehaviour {
	void Start()
	{
		Destroy (gameObject,60);
	}
}
 
