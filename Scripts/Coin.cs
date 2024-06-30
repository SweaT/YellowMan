using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Coin : MonoBehaviour  
{
    [SerializeField] private float YAxisRotationSpeed;
    [SerializeField] private GameObject ParticleEarnCoin;

    void Update()
    {
        transform.Rotate(0, YAxisRotationSpeed * Time.deltaTime, 0) ;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            EarnCoin();
        }
    }

    
    private void EarnCoin()
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(ParticleEarnCoin, gameObject.transform.position, gameObject.transform.rotation);
        AudioManager.Instance.PlayRandomSFX("CoinEarn 1", "CoinEarn 2");


    }

}
