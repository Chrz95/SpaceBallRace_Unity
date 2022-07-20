using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualControls : MonoBehaviour {

    public Rigidbody rb;
    public AudioSource JumpAudio;
    public bool ButtonIsPressed;

    private void Start()
    {
        ButtonIsPressed = false; 
    }

    public void Update()
    {
        if ((ButtonIsPressed) && (this.gameObject.name.Equals("Left_Button")))
               GoLeft();

        if ((ButtonIsPressed) && (this.gameObject.name.Equals("Right_Button")))
                GoRight();
    }

    public void GoLeft()
    {
        rb.AddForce(Vector3.left * PlayerController.OriginalHosSpeed);
    }

    public void GoRight()
    {
        rb.AddForce(Vector3.right * PlayerController.OriginalHosSpeed);
    }

    public void Jump()
    {
        if (PlayerController.OnGround)
        {
            JumpAudio.Play();
            rb.AddForce(Vector3.up * PlayerController.DefaultJumpForce);
        }
    }

    public void onPress()
    {
         ButtonIsPressed = true; 
    }

    public void onRelease()
    {
         ButtonIsPressed = false;
    }
    
}

