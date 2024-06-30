using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HatRaycastPosition : MonoBehaviour
{

    public GameObject head;
    public GameObject hat;

    private void Start()
    {

        SetPositionOfHat();
    }


    public void SetPositionOfHat()
    {
        Ray ray = new Ray(transform.position, -transform.right);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 10f))
        {

            if (hit.collider.tag == "PlayersHead")
            {
                hat.transform.position = hit.point;
            }

        }
    }


}
