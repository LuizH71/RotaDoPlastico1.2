using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]private Transform _playerTransform;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayerBoatAnimation()
    {
        if (_playerTransform.rotation.eulerAngles.z < 23f || _playerTransform.rotation.eulerAngles.z > 337f)
        {
            _animator.SetFloat("velX", 0f);
            _animator.SetFloat("velZ", 1f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 67f && _playerTransform.rotation.eulerAngles.z > 23f)
        {
            _animator.SetFloat("velX", 0.5f);
            _animator.SetFloat("velZ", 0.5f);
        }
        else  if (_playerTransform.rotation.eulerAngles.z < 112f && _playerTransform.rotation.eulerAngles.z > 67f)
        {
            _animator.SetFloat("velX", 1f);
            _animator.SetFloat("velZ", 0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 157f && _playerTransform.rotation.eulerAngles.z > 112f)
        {
            _animator.SetFloat("velX", 0.5f);
            _animator.SetFloat("velZ", -0.5f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 202f && _playerTransform.rotation.eulerAngles.z > 157f)
        {
            _animator.SetFloat("velX", 0f);
            _animator.SetFloat("velZ", -0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 247f && _playerTransform.rotation.eulerAngles.z > 202f)
        {
            _animator.SetFloat("velX", -0.5f);
            _animator.SetFloat("velZ", -0.5f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 292f && _playerTransform.rotation.eulerAngles.z > 247f)
        {
            _animator.SetFloat("velX", -1f);
            _animator.SetFloat("velZ", 0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 337f && _playerTransform.rotation.eulerAngles.z > 292f)
        {
            _animator.SetFloat("velX", -0.5f);
            _animator.SetFloat("velZ", 0.5f);
        }
    }
}
