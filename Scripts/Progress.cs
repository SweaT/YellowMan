using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int Width;
    public int Height;
    public bool[] EnabledChildren;
    public int Level;

}

public class Progress : MonoBehaviour
{

    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();


    public static Progress Instance;


    [SerializeField] TextMeshProUGUI _playerInfoText;

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
            Destroy(gameObject);
        }
    }

    private void Start()
    {
#if UNITY_WEBGL
        LoadExtern();
#endif
    }

    public void SaveCoins(CoinManager coinManager)
    {

        PlayerInfo.Coins = coinManager._numberOfCoins;
    }

    public void AddWidth(int value)
    {
        PlayerInfo.Width += value;
    }

    public void AddHeight(int value)
    {
        PlayerInfo.Height += value;
    }

    public void SaveChildrenBool(bool[] boolList)
    {
        PlayerInfo.EnabledChildren = new bool[boolList.Length];

        for (int i = 0; i < PlayerInfo.EnabledChildren.Length; i++)
        {
            PlayerInfo.EnabledChildren[i] = boolList[i];
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {

        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo.Coins + "\n" + PlayerInfo.Width +
            "\n" + PlayerInfo.Height + "\n" + PlayerInfo.Level + "\n" + PlayerInfo.EnabledChildren;

    }

}
