using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _textNotEnoughCoins;

    public void BuyHeight(TextMeshProUGUI value)
    {
        int price = int.MaxValue;
        try
        {
            price = int.Parse(value.text);
        }
        catch (Exception)
        {

            throw;
        }

        if (_coinManager._numberOfCoins >= price)
        {
            Purchase(price);
            Progress.Instance.AddHeight(15);
            FindObjectOfType<PlayerModifier>().SetHeight(Progress.Instance.PlayerInfo.Height);
        }
        else
        {
            _textNotEnoughCoins.gameObject.SetActive(true);
            StopAllCoroutines();
            _textNotEnoughCoins.color = new Color(_textNotEnoughCoins.color.r, _textNotEnoughCoins.color.g, _textNotEnoughCoins.color.b, 1);
            StartCoroutine(Fade());
        }
    }

    public void BuyWidth(TextMeshProUGUI value)
    {
        int price = int.MaxValue;

        try
        {
            price = int.Parse(value.text);
        }
        catch (Exception)
        {

            throw;
        }

        if (_coinManager._numberOfCoins >= price)
        {
            Purchase(price);
            Progress.Instance.AddWidth(20);
            FindObjectOfType<PlayerModifier>().SetWidth(Progress.Instance.PlayerInfo.Width);
        }
        else
        {
            _textNotEnoughCoins.gameObject.SetActive(true);
            StopAllCoroutines();
            _textNotEnoughCoins.color = new Color(_textNotEnoughCoins.color.r, _textNotEnoughCoins.color.g, _textNotEnoughCoins.color.b, 1);
            StartCoroutine(Fade());
        }
    }

    public void BuyHat(TextMeshProUGUI value, string name)
    {

        if (!HatManager.Instance.GetHat(name)._unlocked)
        {
            int price = int.MaxValue;
            try
            {
                price = int.Parse(value.text);
            }
            catch (Exception)
            {

                throw;
            }

            if (_coinManager._numberOfCoins >= price)
            {
                Purchase(price);
                HatManager.Instance.UnlockHat(name);
                HatManager.Instance.SetHat(name);
            }
            else
            {
                _textNotEnoughCoins.gameObject.SetActive(true);
                StopAllCoroutines();
                _textNotEnoughCoins.color = new Color(_textNotEnoughCoins.color.r, _textNotEnoughCoins.color.g, _textNotEnoughCoins.color.b, 1);
                StartCoroutine(Fade());
            }
        }
        else
        {
            HatManager.Instance.SetHat(name);
        }

    }

    public bool IsHatBought(string name)
    {
         return HatManager.Instance.GetHat(name)._unlocked;
    }

    private void Purchase(int price)
    {
#if UNITY_WEBGL
        Progress.Instance.Save();
#endif
        _coinManager.RemoveCoins(price);
        AudioManager.Instance.PlaySFX("Purchase");
    }


    IEnumerator Fade()
    {
        float alpha = 1f;

        for (; alpha >= 0; alpha -= 0.01f)
        {
            _textNotEnoughCoins.color = new Color(_textNotEnoughCoins.color.r, _textNotEnoughCoins.color.g, _textNotEnoughCoins.color.b, alpha);
            yield return new WaitForSeconds(.02f);
        }

        if (alpha <= 0)
        {
            _textNotEnoughCoins.gameObject.SetActive(false);
            yield break;
        }
    }
}
