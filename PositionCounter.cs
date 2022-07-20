using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class PositionCounter : MonoBehaviour {

	public Text PlaceText ;
	public GameObject Player ;  
	private GameObject[] AIPlayers ; 
	private int PlayerPlace; 
	public Text pointText ;
    public GameObject AdMenu; 

    // Update is called once per frame
    void Start()
	{
		PlayerPlace = PositionTracker.PlayerPlace ; 	
	}

	void Update ()
	{	
		AIPlayers = GameObject.FindGameObjectsWithTag("AI_Player");
        PlayerPlace = PositionTracker.PlayerPlace;
        PlaceText.text = PlayerPlace.ToString() ;

        if ((!AdMenu.activeSelf) && (!PauseMenu.GameIsPaused))
        {
            if (PlayerPlace == 1) // Bonus points if the player is in first,second or third place
            {
                Points.points = Points.points + 3;
                pointText.text = Points.points.ToString();
            }
            else if (PlayerPlace == 2)
            {
                Points.points = Points.points + 2;
                pointText.text = Points.points.ToString();
            }
            else if (PlayerPlace == 3)
            {
                Points.points = Points.points + 1;
                pointText.text = Points.points.ToString();
            }
        }
    }


}

