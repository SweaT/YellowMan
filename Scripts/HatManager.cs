using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    [SerializeField] private Hat[] _hats;

    [SerializeReference] private Hat _currentHat;

    private string _currentHatName;

    private bool _isAnyHatActive = false;

    public static HatManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            var currentHatNameInInstance = Instance._currentHatName;

            for (int i = 0; i < _hats.Length; i++)
            {
                Instance._hats[i].gameObjectHat = _hats[i].gameObjectHat;
            }

            if (currentHatNameInInstance != null)
            {
                Instance._currentHat = GetHat(currentHatNameInInstance);
                Instance.SetHat(currentHatNameInInstance);
            }

            Destroy(gameObject);
        }
    }


    public void SetHat(string name)
    {
        Hat requierdHat = GetHat(name);

        if (requierdHat._unlocked)
        {
            if (_isAnyHatActive)
            {
                if (_currentHat == requierdHat)
                {
                    _currentHat.gameObjectHat.SetActive(false);
                    _currentHat = null;
                    _currentHatName = null;
                    _isAnyHatActive = false;
                    return;
                }

                _currentHat.gameObjectHat.SetActive(false);
            }

            requierdHat.gameObjectHat.SetActive(true);
            _currentHat = requierdHat;
            _currentHatName = _currentHat.gameObjectHat.name;
            _isAnyHatActive = true; 
        }

    }

    public void UnlockHat(string name)
    {
        Hat requierdHat = GetHat(name);

        requierdHat._unlocked = true;
    }

    public Hat GetHat(string name)
    {
        Hat requierdHat = Array.Find(_hats, x => x.gameObjectHat.name == name);
        return requierdHat;
    }

    public int GetHatIndex(string hatName)
    {
        for (int i = 0; i < _hats.Length; i++)
        {
            if (_hats[i].gameObjectHat.name == hatName)
            {
                return i;
            }
        }

        return -1;
    }

}
