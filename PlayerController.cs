using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static float OriginalVertSpeed = 400 ; 
	public static float OriginalHosSpeed = 300 ; 
	public static float NewSpeed  ; 
	public float speed_ver  ;
	public float speed_hos ; 
	private Rigidbody rb; 
	public static bool OnGround ;
	public float JumpForce ; 
	public float maxSpeed ;  //Max speed   
	public static float DefaultJumpForce ; 
	public Material DefaultMaterial ; 
	private AudioSource SphereAudio  ; 
	public AudioClip life , coin , power , jump  ;
	private Vector2 fp ;  // first finger position
	private Vector2 lp ;  // last finger position
    public GameObject Fireball; 
    public static bool ReloadTimeIsOver ;
    public Button FireballButton;
    public static int ReloadTime = 1; 

    // Use this for initialization
    void Start () 
	{
        ReloadTimeIsOver = true;
		DefaultJumpForce = 12000;
		NewSpeed = OriginalVertSpeed/2 ;
        maxSpeed = OriginalVertSpeed/2; 


        if (SphereChoice.material != null)
			this.gameObject.GetComponent<Renderer>().material = SphereChoice.material;
	//	else Debug.Log ("Fail") ; 			
		
		rb = GetComponent<Rigidbody> ();
		speed_ver = OriginalVertSpeed	;
		speed_hos = OriginalHosSpeed ; 
		SphereAudio = GetComponent<AudioSource>();

		Physics.IgnoreLayerCollision(0, 8);	// Passes through any object in layer 8	
		Physics.IgnoreLayerCollision(10, 11); 
		Physics.IgnoreLayerCollision(9,10); // Asteroids and Obstables
        Physics.IgnoreLayerCollision(13,14);
        Physics.IgnoreLayerCollision(0, 14);
        Physics.IgnoreLayerCollision(8, 14);
        Physics.IgnoreLayerCollision(9, 14);
        Physics.IgnoreLayerCollision(10, 14);
        Physics.IgnoreLayerCollision(5, 14);

        OnGround = false ;
		JumpForce = DefaultJumpForce ; 

		Vector3 automovement = new Vector3 (0.0f, 0.0f,1); // Vertical Movement
		rb.AddForce (automovement * speed_ver);
    }
	
	 void OnCollisionExit(Collision collision)
     {
		if (collision.gameObject.CompareTag("Ground"))
		 	OnGround = false;		 
     }
 
     void OnCollisionEnter(Collision collision)
     {
		if (collision.gameObject.CompareTag("Ground"))
		 	OnGround = true;
		else OnGround = false;						 
     }

    void Update()
	{
        if (ReloadTimeIsOver)
            FireballButton.interactable = true;
        else
            FireballButton.interactable = false;
      
        if (Input.GetKeyDown(KeyCode.Space) && OnGround) // Jump
          {		
		  	SphereAudio.PlayOneShot(jump,0.8f);
			rb.AddForce(Vector3.up * JumpForce);			
          }

        if (Input.GetKeyDown(KeyCode.Z) && (ReloadTimeIsOver)) // Fireball
             StartCoroutine(ShootFireBall());

        foreach (Touch touch in Input.touches) 
		{			 
			if (touch.phase == TouchPhase.Began)
			{
				fp = touch.position;
				lp = touch.position;
			}

			if (touch.phase == TouchPhase.Moved )
			{
				lp = touch.position;
			}

			if(touch.phase == TouchPhase.Ended)
			{
				/*if((fp.x - lp.x) > 80) // left swipe
				{
                    rb.AddForce(Vector3.left * speed_hos * 10);
                }
				else if((fp.x - lp.x) < -80) // right swipe
				{
					rb.AddForce (Vector3.right * speed_hos * 10); 
				}*/
				if(((fp.y - lp.y) < -80 ) && OnGround) // up swipe
				{
                    SphereAudio.PlayOneShot(jump, 0.8f);
                    rb.AddForce(Vector3.up * JumpForce);	
				}
            }
		}

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); // Horizontal Movement
        rb.AddForce(movement * speed_hos);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }
  /*   void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f); // Horizontal Movement
        rb.AddForce(movement * speed_hos);

        Vector3 automovement2 = new Vector3(0.0f, 0.0f, 1); // Vertical Movement
        rb.AddForce(automovement2 * NewSpeed);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

    }	*/

	void OnTriggerEnter (Collider collider) // Play pickup sound and destroy pickups
	{
		if (collider.gameObject.CompareTag ("Pickup")) 
        {		
			SphereAudio.PlayOneShot(coin,0.4f);		
			Destroy(collider.gameObject);	
        }

		if (collider.gameObject.CompareTag ("Powerup")) 
		{
			SphereAudio.PlayOneShot(power,0.4f);		
			Destroy(collider.gameObject);
		}		
		
		if (collider.gameObject.CompareTag ("Life"))
		{
			SphereAudio.PlayOneShot(life,0.4f);		
			Destroy(collider.gameObject);
		}	
	}

    public IEnumerator ShootFireBall()
    {
            Vector3 FireBallPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 20);
            ReloadTimeIsOver = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Instantiate(Fireball, FireBallPosition, gameObject.transform.rotation);
            yield return new WaitForSeconds(ReloadTime);
            ReloadTimeIsOver = true;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }               

    public void OnButtonClick()
    {
        StartCoroutine(ShootFireBall());
    }
}

