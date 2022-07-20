using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingOut : MonoBehaviour {

	private float MaxDistance ; 
	public GameObject effect ;
    public AudioSource CrashAudio;

    void Start()
	{
		MaxDistance = -300 ;
    }
	
	void Update () 
	{
			if (transform.position.y < MaxDistance)
			{
				if (this.CompareTag("Player"))
				{
					Instantiate(effect,transform.position,transform.rotation);
					CrashAudio.Play();
					Lives.lives = 0 ;
				}
				else if (this.CompareTag("AI_Player"))
				{
					Instantiate(effect,transform.position,transform.rotation);
					Destroy(transform.parent.gameObject);
				}				
			}			
	}
}
