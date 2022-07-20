using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 

public class ObstacleBehaviour : MonoBehaviour 
{
    private AudioSource audioTeleport ;
	private static GameObject TempShield , effect;
    private int count; 

	void Start ()   
    {
        count = 0; 
        // Avoid obstacles while shielded
        Physics.IgnoreLayerCollision(9, 8);	
		Physics.IgnoreLayerCollision(9, 11);
        Physics.IgnoreLayerCollision(11,15);
    }  

	private IEnumerator OnCollisionEnter (Collision collision)
	{
		GameObject collided = collision.gameObject;
               
        if (collided.tag == "Player")	
		{
                if (TempShield == null)                
                    TempShield = collided.transform.GetChild(0).gameObject;    

                if (effect == null)
                    effect = collided.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;

            PlayerController.ReloadTimeIsOver = true;
                this.gameObject.GetComponent<Rigidbody>().detectCollisions = true; 
				audioTeleport  = collided.GetComponent<AudioSource>();
				Instantiate (effect,collision.transform.position,collision.transform.rotation);			
					
				if (Lives.lives >= 1) // If you still have lives		
				{								
					Lives.lives = Lives.lives - 1 ;
                    collided.GetComponent<Lives>().LivesText.text = Lives.lives.ToString(); 															
					collided.SetActive(false);						
					yield return new WaitForSeconds(1);	
					collided.SetActive(true); // Teleport back						
					collided.transform.position = new Vector3 (collided.transform.position.x,collided.transform.position.y + 15 ,collided.transform.position.z - 100);
					collided.GetComponent<PlayerController>().JumpForce = PlayerController.DefaultJumpForce ; 		

					if (Lives.lives != 0 )  // Temporarily invincible
					{
						audioTeleport.Play();	
						collided.layer = 11 ; 
						TempShield.SetActive(true);
						yield return new WaitForSeconds(5);
						TempShield.SetActive(false);
						collided.layer = 13 ;						
					}					 					
				}
		}

		if ((collided.tag == "Ground") && (gameObject.layer == 9)) // Make asteroids pass through ground		
			this.gameObject.GetComponent<Rigidbody>().detectCollisions = false; 		
		else this.gameObject.GetComponent<Rigidbody>().detectCollisions = true; 

	    if (collided.tag == "AI_Player")	
		{
            if (effect == null)
                effect = collided.transform.parent.gameObject.transform.GetChild(2).gameObject;

            if (effect != null)      
                Instantiate(effect, collision.transform.position, collision.transform.rotation);            

            this.gameObject.GetComponent<Rigidbody>().detectCollisions = true; 
			GameObject Parent = collided.gameObject.transform.parent.gameObject ;	
			Destroy(Parent);
		}
		
	}
}

