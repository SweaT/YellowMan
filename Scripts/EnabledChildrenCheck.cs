using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledChildrenCheck : MonoBehaviour
{

    public List<ButtonHatPurchase> buttonHatPurchasesList;

    public bool[] bools;

    bool alreadysetted = false;

    private void Awake()
    {
        LoadBools();
    }

    private void OnEnable()
    {

        if (!alreadysetted)
        {
            foreach (var item in buttonHatPurchasesList)
            {
                item.SetCheckIcon();
            }

            alreadysetted = true;
        }
    }

    public void GetBools()
    {
        bools = new bool[buttonHatPurchasesList.Count];
        for (int i = 0; i < buttonHatPurchasesList.Count; i++)
        {
            bools[i] = buttonHatPurchasesList[i].purchasedHat;

        }
    }
    public void SaveBools()
    {
        Progress.Instance.SaveChildrenBool(bools);
    }

    public void LoadBools()
    {
        bools = Progress.Instance.PlayerInfo.EnabledChildren;

        for (int i = 0; i < bools.Length; i++)
        {
            buttonHatPurchasesList[i].purchasedHat = bools[i];
        }
    }
}
