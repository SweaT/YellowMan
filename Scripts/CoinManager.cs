using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public int _numberOfCoins;
    [SerializeField] TextMeshProUGUI _text;

    private void Start()
    {
        LoadFromProgress();
        _text.text = _numberOfCoins.ToString();
    }

    public void AddOne()
    {
        _numberOfCoins++;
        _text.text = _numberOfCoins.ToString();

    }

    public void RemoveCoins(int value)
    {
        _numberOfCoins -= value;
        _text.text = _numberOfCoins.ToString();
    }

    public void LoadFromProgress()
    {
        _numberOfCoins = Progress.Instance.PlayerInfo.Coins;
    }

}
