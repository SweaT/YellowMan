using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PreFinishBehaviour _playerPreFinishBehaviour;
    [SerializeField] protected Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _playerMove.enabled = false;
        _playerPreFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        _playerMove.enabled = true;

    }

    public void StartPreFinishBehaviour()
    {
        _playerMove.enabled = false;
        _playerPreFinishBehaviour.enabled = true;
        _animator.ResetTrigger("Jump");

    }

    public void StartFinishBehaviour()
    {
        _playerMove.enabled = false;
        _playerPreFinishBehaviour.enabled = false;
        _animator.SetTrigger("Dance");

    }

}
