using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpBehaviour : MonoBehaviour {

	public GameObject ObstacleObject ;
	private float powerDistance; 
	private GameObject Player ; 
	private int PowerChooser , NumOfPowers ; 
	public List<GameObject> prefabList = new List<GameObject>();
	public GameObject BonusCanceller , SizeIncreaser , SizeDecreaser , ShieldCanceller , UpsideDownCanceller , NoReloadCanceller ;
   // public GameObject MainCamera; 

    private static AudioSource Teleport, AccelarateSound, JumpSound, Asteroid, Grow, ShieldSound, Shrink;
    private static Text BonusLabel, MinusLifeLabel;
    private static GameObject PlayerParent , Sounds;
    private int count ; 

    void Start()
	{
        count = 0;
        PowerChooser = Random.Range(1,16);
        powerDistance = 700 ;

        MinusLifeLabel = GameObject.Find("LivesDecreased").GetComponent<Text>();
        BonusLabel = GameObject.Find("bonus").GetComponent<Text>();
    }

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			Player = collider.gameObject ;
            PlayerParent = Player.transform.parent.gameObject; 

            // Setting sounds/text
            if (count == 0)
            {
                count++;
                Sounds = PlayerParent.transform.GetChild(2).gameObject;

                Teleport = Sounds.transform.GetChild(4).GetComponent<AudioSource>();
                AccelarateSound = Sounds.transform.GetChild(3).GetComponent<AudioSource>();
                JumpSound = Sounds.transform.GetChild(1).GetComponent<AudioSource>();
                Asteroid = Sounds.transform.GetChild(5).GetComponent<AudioSource>();
                Grow = Sounds.transform.GetChild(6).GetComponent<AudioSource>();
                ShieldSound = Sounds.transform.GetChild(7).GetComponent<AudioSource>();
                Shrink = Sounds.transform.GetChild(8).GetComponent<AudioSource>();
            }



            switch (PowerChooser)
      		{
				case 1:
					DecreaseSize();					
					break;
				case 2:
					Shield();			
					break;
				case 3:
                    BonusPoints(16);
                    break;
                case 4:
					TeleportForwards();
					break;
				case 5:
                    InfinitePower();
                    break;
				case 6:
					SpawnObstacle();
					break;
				case 7:
					TeleportBackwards();
					break;
				case 8:
				    IncreaseSize();	
					break;
				case 9:
				    Jump();
					break;
				case 10:
					Accelarate();
					break;
				case 11:
					SpawnAsteroids();					
					break;
				case 12 : 
					BonusPoints(2);
					break;
				case 13 : 
					BonusPoints(4);
					break;
				case 14 : 
					BonusPoints(8);
					break;
				case 15 : 
					DecreaseLife();
					break;
                /*case 16:
                    WorldUpsideDown();
                    break;*/
                default:					
					break;
			}	
			Destroy(gameObject);	// Destroy power-up	
		}		
	}

	void DecreaseSize()
	{		
		Shrink.Play();
		Time.timeScale =1  ;
		Player.transform.localScale = (Player.transform.localScale)/2 ; 
		Player.GetComponent<TrailRenderer>().startWidth = Player.GetComponent<TrailRenderer>().startWidth/2 ;
		Instantiate(SizeIncreaser,new Vector3(Player.gameObject.transform.position.x,Player.transform.position.y,Player.transform.position.z + powerDistance),transform.rotation);
	}	

	void Shield()
	{				
		ShieldSound.Play();
		Time.timeScale = 1  ;
		Player.layer = 11 ; // Temporarily invincible
		Player.transform.GetChild(0).gameObject.SetActive(true);//Enable Shield
		//GetComponent<MeshRenderer>().enabled = false ; // Renders powerup invisible		
		//GetComponent<Collider>().enabled = false ; 				
		Instantiate(ShieldCanceller,new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z + powerDistance),transform.rotation);
	}
	void DecreaseLife()
	{
        MinusLifeLabel.text = "-1";
		Lives.lives = Lives.lives - 1 ; 
		Player.GetComponent<Lives>().LivesText.text = Lives.lives.ToString(); 
		Instantiate(BonusCanceller,new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z + powerDistance),transform.rotation);
	}

	/*void WorldUpsideDown()
	{
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 180; 
        MainCamera.transform.rotation = Quaternion.Euler(rotationVector);//Power effect
        Instantiate(UpsideDownCanceller,new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z + powerDistance),transform.rotation);
	}*/

	void BonusPoints(int multiplier)
	{	
		Player.GetComponent<Points>().points_multiplier = multiplier ;//Power effect
        BonusLabel.text = multiplier.ToString() + 'X';
        Instantiate(BonusCanceller, new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + powerDistance), transform.rotation);		
	}

    void InfinitePower()
    {
        PlayerController.ReloadTime = 0; 
        Instantiate(NoReloadCanceller, new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + powerDistance), transform.rotation);
    }

    void IncreaseSize()
	{		
		Grow.Play();
		Player.transform.localScale = (Player.transform.localScale)*2 ; 
		Player.GetComponent<TrailRenderer>().startWidth = Player.GetComponent<TrailRenderer>().startWidth*2 ;
        Instantiate(SizeDecreaser,new Vector3(Player.gameObject.transform.position.x,Player.transform.position.y,Player.transform.position.z + powerDistance),transform.rotation);
	}	

	void SpawnObstacle()
	{			
		GameObject NewObstacle = Instantiate (ObstacleObject,new Vector3(Player.transform.position.x,Player.transform.position.y,Player.transform.position.z - 10),transform.rotation);		//Power effect	
		Destroy(NewObstacle,15);
	}

	void TeleportForwards()
	{				
		Teleport.Play();
		Player.transform.position = new Vector3 (Player.transform.position.x,Player.transform.position.y,Player.transform.position.z + 100);	
	}

	void TeleportBackwards()
	{	
		Teleport.Play();
		Player.transform.position = new Vector3 (Player.transform.position.x,Player.transform.position.y,Player.transform.position.z - 100);	
	}

	void Jump()
	{
		JumpSound.Play();
		Player.GetComponent<Rigidbody>().AddForce(Vector3.up * 25000);
	}

	void Accelarate()
	{
		AccelarateSound.Play();
		Player.GetComponent<Rigidbody>().AddForce(Vector3.forward * 3000);
	}

	void SpawnAsteroids()
	{		
		Asteroid.Play();	
		int prefabIndex = UnityEngine.Random.Range(0,prefabList.Count-1);
		int NumOfAsteroids = 10 ; 					

		for (int i = 1; i <= NumOfAsteroids; i++)
        {
			float AsteroidXPos = Random.Range(-160,160);
			float AsteroidYPos = Random.Range(10,100);
			float AsteroidZPos = Random.Range(transform.position.z + 10,transform.position.z - 150);
            Instantiate(prefabList[prefabIndex],new Vector3(AsteroidXPos,AsteroidYPos,AsteroidZPos),transform.rotation);
        }
	}
}
