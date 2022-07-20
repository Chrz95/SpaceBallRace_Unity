using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {

    /*public Slider slider ;
	public Text progressText ; 

	public List<GameObject> MenuElements = new List<GameObject>();

public void LoadLevel()
	{
		StartCoroutine(LoadAsynchronously("EndlessLevel"));
		Time.timeScale = 1f;
		PauseMenu.GameIsPaused = false; 	
	}	

	IEnumerator LoadAsynchronously (string name)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(name);

		// Disable all buttons and title
		for (int i = 0; i <= MenuElements.Count-1; i++)
        {			
            MenuElements[i].SetActive(false);
        }

		slider.gameObject.SetActive(true);

		while (!operation.isDone)
		{			
			float progress = Mathf.Clamp01(operation.progress / 0.9f); // We make the progress go from 0 to 1 not from 0 to 0.9

			slider.value = progress ; 
			progressText.text = progress * 100f + "%"; 
			yield return null ; 
		}
	}*/

    public Button Continue;

    private void Start()
    {
        if ((PlayerPrefs.GetFloat("High Score", 0) != 0f) || (PlayerPrefs.GetFloat("Max Distance", 0) != 0f))
            Continue.interactable = true;
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }

}
