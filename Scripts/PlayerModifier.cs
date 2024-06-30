#define cheat
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerModifier : MonoBehaviour
{

    [SerializeField] int _widtht;
    [SerializeField] int _heght;

    float _widthMultiplier = 0.0005f;
    float _heightMultiplier = 0.01f;

    [SerializeField] Renderer _renderer;

    [SerializeField] Transform _topSpine;
    [SerializeField] Transform _bottomSpine;

    [SerializeField] Transform _collidderTransform;

    [SerializeField] GameObject _hat;
    [SerializeField] HatRaycastPosition _position;
    [SerializeField] SphereCollider _headSphere;
    [SerializeField] float _hatScaleMiltiplier;


    float _defaultHeadSphereRadius;
    Vector3 _defaultHatScale;


    

    private void Start()
    {
        _defaultHeadSphereRadius = _headSphere.radius;
        _defaultHatScale = _hat.transform.localScale;

        SetHeight(Progress.Instance.PlayerInfo.Height);
        SetWidth(Progress.Instance.PlayerInfo.Width);

    }

    void Update()
    {
        
        float offsetY = _heght * _heightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _collidderTransform.localScale = new Vector3(1,1.9f + _heght * _heightMultiplier,1);

#if cheat
        Cheat(); 
#endif
    }

    public void AddWidth(int value)
    {
        
        if (_widtht + value > 0)
        {
            _widtht += value;
            _headSphere.radius += value * _widthMultiplier;
            _renderer.material.SetFloat("_PushValue", _widtht * _widthMultiplier);
            AudioManager.Instance.PlaySFX("AddWidth");

            _hat.transform.localScale += new Vector3(value * _hatScaleMiltiplier, value * _hatScaleMiltiplier, value * _hatScaleMiltiplier);
            _position.SetPositionOfHat();

        }
        else 
        {

            _widtht = 0;
            _renderer.material.SetFloat("_PushValue", _widtht * _widthMultiplier);
            AudioManager.Instance.PlaySFX("AddWidth");

            _hat.transform.localScale = _defaultHatScale;
            _headSphere.radius = _defaultHeadSphereRadius;
        }

    }

    public void SetWidth(int value)
    {
        if (value >= 0)
        {
            _widtht = value;
            _headSphere.radius = _defaultHeadSphereRadius + value * _widthMultiplier;
            _hat.transform.localScale =  _defaultHatScale + new Vector3(value * _hatScaleMiltiplier, value * _hatScaleMiltiplier, value * _hatScaleMiltiplier);
            _renderer.material.SetFloat("_PushValue", _widtht * _widthMultiplier);         
        }
    }

    public void AddHeight(int value)
    {
        if (_heght + value > -1)
        {
            _heght += value;
            AudioManager.Instance.PlaySFX("AddHeight");
        }
        else
        {
            _heght = -1;
            AudioManager.Instance.PlaySFX("AddHeight");
        }
    }

    public void SetHeight(int value)
    {
        if (value >= -1)
        {
            _heght = value;
        }
    }

    public void HitBarier()
    {

        if (_heght > -1)
        {
            AddHeight(-15);
        }
        else if (_widtht > 0)
        {
            AddWidth(-20);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ShowFinishWidnow();
    }

    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_widtht == Mathf.Clamp(_widtht, 0, 380))
            {
                AddWidth(20);
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_widtht == Mathf.Clamp(_widtht, -20, 400))
            {
                AddWidth(-20);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddHeight(20);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddHeight(-20);
        }
    }
}
