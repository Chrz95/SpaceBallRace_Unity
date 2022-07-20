using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationInput : MonoBehaviour {
    public Vector3 movement;
    public float speed_hos;
    private Rigidbody rb;
    private float Sensitivity; 

    private void Start()
    {
        Sensitivity = 3.5f; 
        rb = gameObject.GetComponent<Rigidbody>(); 
        speed_hos = 800; 
        movement = new Vector3(Sensitivity * Input.acceleration.x, 0, 1f) *speed_hos;
    }

    // Update is called once per frame
    void FixedUpdate () {
        movement = new Vector3(Sensitivity * Input.acceleration.x, 0, 1f) * (speed_hos/2);
        rb.AddForce(movement);
        // transform.Translate(-Input.acceleration.x, 0, 0);
    }
}
