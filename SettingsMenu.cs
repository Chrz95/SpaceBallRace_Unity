using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer ;
    public Text OpponentsText;
    
    public void SetVolume0(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume1", volume);
    }

    public void SetVolume (float volume)
	{
		audioMixer.SetFloat("Volume",volume);
	}

	public void SetVolume1 (float volume)
	{
		audioMixer.SetFloat("Volume1",volume);
	}
    	

	public void SetNumofBots (float bots)
	{
		AI_Generator.NumOfEnemies = 30;
        AI_Generator.NumOfEnemies = (int)bots; 
    }

    public void SetText(float bots)
    {
        OpponentsText.text = bots.ToString();
    }

    public void SetDifficulty(float level)
    {
        int level1 = (int) level; 

        switch (level1)
        {
            case 1: // Easy 
                PlayerController.OriginalVertSpeed = 400f;
                AIPlayerBehaviour.OriginalVertSpeed = 405f; 
                PlayerController.ReloadTime = 1;
                Lives.OriginalLives = 3;
                Lives.lives = 3;
                AsteroidGenerator.NumOfAsteroids = 5; 
                break;
            case 2: // Medium
                PlayerController.OriginalVertSpeed = 700f;
                AIPlayerBehaviour.OriginalVertSpeed = 705f;
                PlayerController.ReloadTime = 2;
                Lives.lives = 2;
                Lives.OriginalLives = 2;
                AsteroidGenerator.NumOfAsteroids = 10;
                break;
            case 3: // Hard
                PlayerController.OriginalVertSpeed = 1000f;
                AIPlayerBehaviour.OriginalVertSpeed = 1005f;
                PlayerController.ReloadTime = 3;
                Lives.lives = 1;
                Lives.OriginalLives = 1;
                AsteroidGenerator.NumOfAsteroids = 15;
                break;
        }         
    }
}
