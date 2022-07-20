using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoReloadCanceller : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController.ReloadTime = 3;
            Destroy(gameObject); //Destroys Canceller
        }

    }
}
