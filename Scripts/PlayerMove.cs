#define Mouse

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _eulerSpeed;
    [SerializeField, Tooltip("true = mousemovement, false = wasd movement")] private bool _typeOfPlayerControl;

    [SerializeField] protected GameObject _ground;
    [SerializeField] protected Animator _animator;
    [SerializeField] private ParticleSystem _particleSystem;

    void Start()
    {
        transform.position.Set(_ground.transform.position.x, transform.position.y, transform.position.z);
        _oldMousePositionX = Input.mousePosition.x;
    }

    private void WASDMovement()
    {
        // Управление кнопками WASD

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _moveSpeed *= 1.5f;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            _moveSpeed /= 1.5f;


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, _moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-_moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
        }


    }


    protected float _oldMousePositionX;
    protected float _eulerY;

    protected virtual void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _animator.SetBool("Run", true);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * _moveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -3.5f, 3.5f);
            transform.position = newPosition;

            float _deltaMousePositionX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += _deltaMousePositionX * _eulerSpeed;
            _eulerY = Mathf.Clamp(_eulerY, -70, 70);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Run", false);
        }

        Jump();

    }
    void Update()
    {

#if WASD
        WASDMovement();
#else  
        MouseMovement();
#endif

    }

    [SerializeField] protected float _jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] float gravityScale = 0.5f;
    private float velocity;
    private bool isObjOnJump = false;
    private float oldPositionY;


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isObjOnJump == false)
        {
            oldPositionY = transform.position.y;
            _animator.SetBool("Jump", true);
            velocity = _jumpForce;
            transform.Translate(0, velocity * Time.deltaTime, 0);
            isObjOnJump = true;
            _particleSystem.Stop();
            AudioManager.Instance.PlaySFX("Jump 1");

        }

        if (isObjOnJump)
        {
            velocity += gravity * gravityScale * Time.deltaTime;
            transform.Translate(0, velocity * Time.deltaTime, 0);

            if (transform.position.y <= oldPositionY)
            {
                transform.position = new Vector3(transform.position.x, oldPositionY, transform.position.z);
                isObjOnJump = false;
                _animator.SetBool("Jump", false);
                _particleSystem.Play();
            }

        }
    }
}
