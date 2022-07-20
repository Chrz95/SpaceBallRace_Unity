using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false ; 
	public GameObject pauseMenuUI , Game_UI ; 
	public AudioSource CameraSound , PauseMenuOn , PauseMenuOff  ;   
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused)
				Resume();
			else 
				Pause();
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		PauseMenuOff.Play(); 
		Game_UI.SetActive(true);
		Time.timeScale = 1f;
		GameIsPaused = false; 
		CameraSound.UnPause();		  
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		PauseMenuOn.Play(); 
		Game_UI.SetActive(false);
		Time.timeScale = 0f;
		GameIsPaused = true; 	
		CameraSound.Pause();	
	}

	public void QuitGame()
	{
		Application.Quit();
	}	

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu 3D");
	}

	public void Reset()
	{
		Time.timeScale = 1f;
		GameIsPaused = false; 	
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

 
}
