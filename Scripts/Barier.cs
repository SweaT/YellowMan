using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    private PlayerModifier playerModifier;
    [SerializeField] private GameObject _particleSystem;

    private void OnTriggerEnter(Collider other)
    {

        playerModifier = other?.attachedRigidbody?.GetComponent<PlayerModifier>();

          
        if (playerModifier != null)
        {
            playerModifier.HitBarier();
            Destroy(gameObject);

            Instantiate(_particleSystem, gameObject.transform.position, gameObject.transform.rotation);

            AudioManager.Instance.PlaySFX("BrickCrush");
        }

    }
}
