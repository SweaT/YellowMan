using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HeightBlock : MonoBehaviour
{
    [SerializeField] private int _heightValue;



    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier != null)
        {
            playerModifier.AddHeight(_heightValue);
        }

    }
}
