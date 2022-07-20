using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerBehaviour : MonoBehaviour {

	public static float OriginalVertSpeed = 405 ; 
	public static float OriginalHosSpeed = 800 ; 
	public static float NewSpeed ;
	public float speed_ver  ;
	public float speed_hos ; 
	private Rigidbody rb; 
	public float JumpForce ; 
	public float maxSpeed = 500f;  //Max speed   
	public static float DefaultJumpForce = 1600 ;  
	private Ray ObstacleRay , ObstacleRay1 , ObstacleRay2 , ObstacleRay3 , ObstacleRay4 , ObstacleRay5;
	//private RaycastHit hit1 , hit2 , hit3 , hit4 ; 
	private Vector3 RayPosition ;

	public LayerMask myLayerMask ;  

	private float ObstacleDistanceStraight , ObstacleDistanceOther ;
    private bool StraightRay, RightRay, LeftRay, UpRay, UpLeftRay, UpRightRay; 

    // Use this for initialization
    void Start () 
	{				
		ObstacleDistanceStraight = 90 ; 
		ObstacleDistanceOther = ObstacleDistanceStraight + 10 ; 
		NewSpeed = OriginalVertSpeed/2 ;
        maxSpeed = OriginalVertSpeed / 2;

        rb = GetComponent<Rigidbody> ();
		speed_ver = OriginalVertSpeed	;
		speed_hos = OriginalHosSpeed ; 
		JumpForce = DefaultJumpForce ; 
  		
		Physics.IgnoreLayerCollision(12,12);	
		Physics.IgnoreLayerCollision(12,13);	

		Vector3 automovement = new Vector3 (0.0f, 0.0f,1); // Vertical Movement
		rb.AddForce (automovement * speed_ver); 	
	}
	
	void FixedUpdate()
	{
		RayPosition = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);

		ObstacleRay = new Ray(RayPosition,Vector3.forward);	
		ObstacleRay1 = new Ray(RayPosition,new Vector3(-0.2f,0,1));	
		ObstacleRay2 = new Ray(RayPosition,new Vector3(0.2f,0,1));
		ObstacleRay3 = new Ray(RayPosition,new Vector3(0f,0.2f,1));
        ObstacleRay4 = new Ray(RayPosition, new Vector3(0.2f, 0.2f, 1));
        ObstacleRay5 = new Ray(RayPosition, new Vector3(-0.2f, 0.2f, 1));

        StraightRay = Physics.Raycast(ObstacleRay,ObstacleDistanceStraight,myLayerMask);
		LeftRay = Physics.Raycast(ObstacleRay1,ObstacleDistanceOther,myLayerMask);  
		RightRay = Physics.Raycast(ObstacleRay2,ObstacleDistanceOther,myLayerMask); 
		UpRay = Physics.Raycast(ObstacleRay3,ObstacleDistanceOther,myLayerMask);
        UpRightRay = Physics.Raycast(ObstacleRay4, ObstacleDistanceOther, myLayerMask);
        UpLeftRay = Physics.Raycast(ObstacleRay5, ObstacleDistanceOther, myLayerMask);

        //Debug.DrawRay (RayPosition,Vector3.forward*ObstacleDistanceStraight,Color.red,20,true); // Test ray
        //Debug.DrawRay (RayPosition,new Vector3(-0.15f,0,1)*ObstacleDistanceOther,Color.green,20,true); // Test ray
        //Debug.DrawRay (RayPosition,new Vector3(0.15f,0,1)*ObstacleDistanceOther,Color.blue,20,true); // Test ray
        //Debug.DrawRay (RayPosition,new Vector3(0f,0.2f,1)*(ObstacleDistanceOther + 50),Color.yellow,20,true); // Test ray

        if ((!StraightRay) && (!LeftRay) && (RightRay)) // 001
		{ 
			//Debug.Log("001");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{	
				//Debug.Log("0010");		
				rb.AddForce (Vector3.left * speed_hos); 
			}
			else SidesofTheRoad () ;										
		}
		else if ((!StraightRay) && (LeftRay) && (!RightRay)) //010
		{
			//Debug.Log("010");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{		
				//Debug.Log("0100");					
				rb.AddForce (Vector3.right * speed_hos); 	
			}
			else SidesofTheRoad () ;			
		}
		else if ((!StraightRay) && (LeftRay) && (RightRay)) //011
		{
			//Debug.Log("011");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{			
					//Debug.Log("0110");	
					rb.AddForce(Vector3.up * JumpForce);	 // Jump 
			}
			else SidesofTheRoad () ;					 			
		}
		else if ((StraightRay)  && (!LeftRay)  && (!RightRay)) //100
		{	
			//Debug.Log("100");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{					
				if (this.gameObject.transform.localPosition.x <= 0) 	
				{
					//Debug.Log("1000");
					rb.AddForce (Vector3.right * speed_hos); 
				}							
				else
				{
					//Debug.Log("1001");
					rb.AddForce (Vector3.left * speed_hos); 
				}
			}	
			else SidesofTheRoad () ;	
		}
		else if ( (StraightRay)  && (!LeftRay) && (RightRay)) // 101
		{
			//Debug.Log("101");			
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{
				//Debug.Log("1010");
				rb.AddForce (Vector3.left * speed_hos); 						
			}
			else SidesofTheRoad () ;				
		}
		else if ((StraightRay)  && (LeftRay) && (!RightRay)) // 110
		{
			//Debug.Log("110");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{		
				//Debug.Log("1100");	
				rb.AddForce (Vector3.right * speed_hos); 
			}
			else SidesofTheRoad () ;
		}
		else if ((StraightRay)  && (LeftRay) && (RightRay)) // 111
		{			
			//Debug.Log("111");
			if ((this.gameObject.transform.localPosition.x <=  4.5f) && (this.gameObject.transform.localPosition.x >= -11f))
			{		
				//Debug.Log("1110");				
				if (!UpRay) rb.AddForce (Vector3.up * JumpForce);
				if (UpRightRay) rb.AddForce (Vector3.left * (speed_hos*2)); 
				else if (UpLeftRay) rb.AddForce (Vector3.right * (speed_hos*2)); 					
			}	
			else SidesofTheRoad () ;
		}

		// Moving forward
		Vector3 automovement2 = new Vector3 (0.0f, 0.0f,1); // Vertical Movement
		rb.AddForce (automovement2 * NewSpeed);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

	void SidesofTheRoad ()
	{
			if (this.gameObject.transform.localPosition.x >=  4.5f) 			
			{
                if (!UpRay) rb.AddForce(Vector3.up * JumpForce);
                if ((UpRightRay) && (!UpLeftRay)) rb.AddForce(Vector3.left * (speed_hos * 2));
                else if ((!UpRightRay) && (UpLeftRay)) rb.AddForce(Vector3.right * (speed_hos * 2));
                else if ((!UpRightRay) && (!UpLeftRay)) rb.AddForce(Vector3.right * (speed_hos * 2));
                else rb.AddForce(Vector3.left * (speed_hos * 2));
        }
			else if  (this.gameObject.transform.localPosition.x <= -11f) 				
			{
                  if (!UpRay) rb.AddForce(Vector3.up * JumpForce);
                  if ((UpRightRay) && (!UpLeftRay)) rb.AddForce(Vector3.left * (speed_hos * 2));
                  else if ((!UpRightRay) && (UpLeftRay)) rb.AddForce(Vector3.right * (speed_hos * 2));
                  else if ((!UpRightRay) && (!UpLeftRay)) rb.AddForce(Vector3.right * (speed_hos * 2));
                  else rb.AddForce(Vector3.right * (speed_hos * 2));

        }	
	}	
}
