using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType
{
    Width,
    Height,
}


public class GateAppearence : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private Image topImage;
    [SerializeField] private Image glassImage;

    [SerializeField] private Color colorPositive;
    [SerializeField] private Color colorNegative;


    [SerializeField] private GameObject _expandLable;
    [SerializeField] private GameObject _shrinkLable;

    [SerializeField] private GameObject _upLable;
    [SerializeField] private GameObject _downLable;

    public void UpdateVisual(DeformationType deformationType, int value)
    {
        // gate color set
        switch (value)
        {
            case < 0:
                SetColor(colorNegative);
                text.text = value.ToString();
                break;

            case 0:
                SetColor(Color.gray);
                text.text = value.ToString();
                break;

            case > 0:
                SetColor(colorPositive);
                text.text = "+" + value.ToString();
                break;

        }

        _expandLable.SetActive(false);
        _shrinkLable.SetActive(false);
        _upLable.SetActive(false);
        _downLable.SetActive(false);


        //gate image and lable set
        switch (deformationType)
        {
            case DeformationType.Width:
                if (value > 0)
                {
                    _expandLable.SetActive(true);
                }
                else
                {
                    _shrinkLable.SetActive(true);
                }
                break;

            case DeformationType.Height:
                if (value > 0)
                {
                    _upLable.SetActive(true);
                }
                else
                {
                    _downLable.SetActive(true);
                }
                break;

        }

        // gate image set
        if (deformationType == DeformationType.Width)
        {
            if (value > 0 )
            {

            }

        }
        else if (deformationType == DeformationType.Height)
        {

        }

    }

    private void SetColor(Color color)
    {
        topImage.color = color;
        glassImage.color = new Color(color.r, color.g, color.b, 0.3f);
    }

}
