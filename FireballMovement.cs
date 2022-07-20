using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballMovement : MonoBehaviour
{
    private Rigidbody rb;
    public static float Speed;
    public GameObject effect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed = 1500;
        Destroy(this.gameObject, 30);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 automovement = new Vector3(0.0f, 0.0f, 1); // Vertical Movement
        rb.AddForce(automovement * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AI_Player"))
        {
            Instantiate(effect, collision.gameObject.transform.position, collision.gameObject.transform.parent.transform.rotation);
            Destroy(collision.gameObject.transform.parent.gameObject);            
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        if  (collision.gameObject.CompareTag("Enemies"))
        {
            Instantiate(effect, collision.gameObject.transform.position, collision.gameObject.transform.parent.transform.rotation);
            Destroy(collision.gameObject);
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
