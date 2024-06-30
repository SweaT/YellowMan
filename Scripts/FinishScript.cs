using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField, Tooltip("Game object name, that finish particles attached to")]
    private string _particleSistemName;

    private void OnTriggerEnter(Collider other)
    {

        PlayerBehavior newBehaviourScript = other.attachedRigidbody.GetComponent<PlayerBehavior>();

        if (newBehaviourScript != null )
        {

            newBehaviourScript.StartFinishBehaviour();
            FindObjectOfType<GameManager>().ShowFinishWidnow();

            transform.Find(_particleSistemName)?.gameObject.SetActive(true);
            AudioManager.Instance.PlayMusic("FinishSound 1");

        }

    }
}
