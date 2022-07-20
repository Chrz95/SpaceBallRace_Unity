using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour {

	public List<Material> MatListList = new List<Material>();
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material = MatListList[Random.Range(0,MatListList.Count)];
	}
	
	// Update is called once per frame
}
