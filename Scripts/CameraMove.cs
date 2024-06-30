using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [Header("Camera Transform")]

    [SerializeField] protected GameObject target;
    private Vector3 positionOfObject = new Vector3();


    [SerializeField] protected Vector3 _cameraDelay = new Vector3(0, 3, -2.5f);
    [SerializeField] protected Vector3 _cameraRotation = new Vector3(21f, 0, 0);
    [SerializeField] protected int _cameraFieldOfView = 60;

    void Start()
    {
        transform.parent = null;
        // Задали первоначальные координаты камеры
        transform.localEulerAngles = _cameraRotation;
        Camera.main.fieldOfView = _cameraFieldOfView;
        positionOfObject = target.transform.position;
        transform.position = positionOfObject + _cameraDelay;

    }

    void LateUpdate()
    {

        // Отследили позицию объекта в пространстве
        if (target != null)
        {
            positionOfObject = target.transform.position;
        }
        

        // если объект двинулся
        if (transform.position != positionOfObject - _cameraDelay)
        {

            // Определяем конечное состояние камеры
            transform.position = positionOfObject + _cameraDelay;


        }

    }
}
