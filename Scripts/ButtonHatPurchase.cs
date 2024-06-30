using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHatPurchase : MonoBehaviour
{
    public Button buttonPurchase;
    public bool purchasedHat = false;
    [SerializeField] private Shop _shop;
    [SerializeField] TextMeshProUGUI value;
    [SerializeField] string _name;
    [SerializeField] GameObject[] _objectsToDisable;
    [SerializeField] GameObject[] _objectsToEnable;

    void OnEnable()
    {
        //Register Button Events
        buttonPurchase.onClick.AddListener(() => _shop.BuyHat(value, _name));
        buttonPurchase.onClick.AddListener(() => PurchasedIcons());
        
    }

    void OnDisable()
    {
        //Un-Register Button Events
        buttonPurchase.onClick.RemoveAllListeners();
    }

    public void PurchasedIcons()
    {
        Hat requieredHat = HatManager.Instance.GetHat(_name);
        if (requieredHat._unlocked)
        {
            for (int i = 0; i < _objectsToDisable.Length; i++)
            {
                _objectsToDisable[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < _objectsToEnable.Length; i++)
            {
                _objectsToEnable[i].gameObject.SetActive(true);
            }

            purchasedHat = true;
        }

    }

    public void SetCheckIcon()
    {
        if (purchasedHat)
        {
            for (int i = 0; i < _objectsToDisable.Length; i++)
            {
                _objectsToDisable[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < _objectsToEnable.Length; i++)
            {
                _objectsToEnable[i].gameObject.SetActive(true);
            }
        }
    }
}
