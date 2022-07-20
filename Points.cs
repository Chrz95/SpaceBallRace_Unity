using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public static int points ; 
	public int points_multiplier  ; 
	public Text pointText , HighScoreText ;
    public AudioSource Fireworks; 

	// Use this for initialization
	void Start ()
    {
		//Points
		points = 0 ; 	
		points_multiplier = 1 ; 
		SetPointsText ();
        HighScoreText.text = PlayerPrefs.GetFloat("High Score", 0).ToString();
    }
	
	void OnTriggerEnter (Collider Pickup)
	{
		if (Pickup.gameObject.CompareTag ("Pickup"))
        {	
			points = points + (5*points_multiplier) ;	
			SetPointsText ();         
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("High Score") < points) // Update max distance
        {
            PlayerPrefs.SetFloat("High Score", points);
            HighScoreText.text = PlayerPrefs.GetFloat("High Score", 0).ToString();
            //Fireworks.Play(); 
        }
    }

    public void SetPointsText ()
	{
		pointText.text = points.ToString(); 
	}
}
