using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void AuthExtern();

    [DllImport("__Internal")]
    private static extern void Rate();


    [SerializeField] TextMeshProUGUI _txt;
    [SerializeField] RawImage _photo;

    public void Auth()
    {

#if UNITY_WEBGL
        AuthExtern();
#endif

    }

    public void SetName(string name)
    {
        _txt.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string mediaURL)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaURL);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    public void RateGame()
    {

#if UNITY_WEBGL
        Rate();
#endif

    }
}
