using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	public static int lives = 3 ;
    public static int OriginalLives = 3;
	public Text LivesText ; 
	public AudioSource CrashAudio , GameOverAudio; 
	public GameObject AdsMenu ; 
	

	// Use this for initialization
	void Start () {

        LivesText.text = lives.ToString(); 
	}
	void Update()
	{
		if (lives==0)
		{
			GameOverAudio.Play();//Game Over Sound
			this.gameObject.SetActive(false);
            Time.timeScale = 0f;
            AdsMenu.SetActive(true);
		} 
	}
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.CompareTag ("Life"))
        {				
			lives = lives + 1 ; 
			LivesText.text = lives.ToString();  			
        }
	}

	 void OnCollisionEnter(Collision collision)
     {
		 if (collision.gameObject.CompareTag("Obstacle"))
		 {
			 CrashAudio.Play();
		 }
     }
}
