using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehavior playerMove = other?.attachedRigidbody?.GetComponent<PlayerBehavior>();

        if (playerMove != null)
        {
            playerMove.StartPreFinishBehaviour();

        }
    }
      
}


