using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingBarier : MonoBehaviour
{
    [SerializeField] private Vector3 _firstPoint;
    [SerializeField] private Vector3 _secondPoint;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    private bool _isMovingToFirst = true;

    void Update()
    {

        transform.Rotate(_rotation.x * Time.deltaTime, _rotation.y * Time.deltaTime, _rotation.z * Time.deltaTime);

        if (_isMovingToFirst)
        {
            transform.position = Vector3.MoveTowards(transform.position, _firstPoint, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _secondPoint, _speed * Time.deltaTime);
        }

        if (transform.position == _firstPoint)
        {
            _isMovingToFirst = false;
        }
        else if (transform.position == _secondPoint) 
        { 
           _isMovingToFirst = true; 
        }

    }
}
