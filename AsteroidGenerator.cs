using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {

public List<GameObject> prefabList = new List<GameObject>();
private float AsteroidXPos , AsteroidYPos  ; 
private float AsteroidZPos ; 
public static int NumOfAsteroids = 5 ;
private int MinDistance ; 
private GameObject Sphere ; 
private int count ; 

	// Use this for initialization
	void Start ()
    {
        Sphere = GameObject.Find("Sphere_Player");
        MinDistance = 500 ; 	
		count = 0 ;
	}

	void Update ()
	{
        if (Sphere != null)
        {
            if ((Mathf.Abs(this.gameObject.transform.position.z - Sphere.transform.position.z) <= MinDistance) && (count == 0))
            {
                count++;
                int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count - 1);

                for (int i = 0; i <= NumOfAsteroids; i++)
                {
                    AsteroidXPos = Random.Range(-150, 150);
                    AsteroidYPos = Random.Range(this.gameObject.transform.position.y + 10, this.gameObject.transform.position.y + 120);
                    AsteroidZPos = Random.Range(transform.position.z, transform.position.z + 150);
                    Instantiate(prefabList[prefabIndex], new Vector3(AsteroidXPos, AsteroidYPos, AsteroidZPos), transform.rotation);
                }
            }
        }
	}
}
