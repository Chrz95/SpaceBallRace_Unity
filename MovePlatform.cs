using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    //adjust this to change speed
    private float speed = 2f;
    //adjust this to change how high it goes
    private float height = 25f;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

   void Update()
    {       
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY * height, pos.z);
    }

}
