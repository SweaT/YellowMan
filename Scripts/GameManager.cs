using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _lvlText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] CoinManager _coinManager;
    [SerializeField] EnabledChildrenCheck _enabledChildrenCheck;

    private void Start()
    {
        _lvlText.text = SceneManager.GetActiveScene().name;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
            case 3:
                AudioManager.Instance.PlayMusic("MainTheme 2");
                break;

            default:
                AudioManager.Instance.PlayMusic("MainTheme 1");
                break;
        }
    }

    public void Play()
    {
       
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehavior>().Play();

#if UNITY_WEBGL
        Progress.Instance.Save();
#endif

    }

    public void LoadNextLVL()
    {

#if UNITY_WEBGL
        Progress.Instance.Save();
#endif


        int next = SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            Progress.Instance.PlayerInfo.Level = next - 1;
            Progress.Instance.SaveCoins(_coinManager);
            SceneManager.LoadScene(next);
            _enabledChildrenCheck.GetBools();
            _enabledChildrenCheck.SaveBools();
        }
        else
        {
            Progress.Instance.SaveCoins(_coinManager);
            SceneManager.LoadScene(1);
            _enabledChildrenCheck.GetBools();
            _enabledChildrenCheck.SaveBools();
        }

    }

    public void ShowFinishWidnow()
    {
        _finishWindow.SetActive(true);
    }
}
