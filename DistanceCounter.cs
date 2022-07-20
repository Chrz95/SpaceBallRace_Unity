using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour {

	public Text Distance ;
    public Text Max_Distance;
    public AudioSource Fireworks; 
    // Use this for initialization
    void Start ()
    {
		Distance.text = "0" ;
        Max_Distance.text = PlayerPrefs.GetFloat("Max Distance",0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        float Distance_Count = Mathf.Floor(transform.position.z + 600);
        Distance.text = Distance_Count.ToString();

        if (PlayerPrefs.GetFloat("Max Distance") < Distance_Count) // Update max distance
        {
            PlayerPrefs.SetFloat("Max Distance", Distance_Count);
            Max_Distance.text = PlayerPrefs.GetFloat("Max Distance", 0).ToString();
            //Fireworks.Play(); 
        }
             

        

    }
}
