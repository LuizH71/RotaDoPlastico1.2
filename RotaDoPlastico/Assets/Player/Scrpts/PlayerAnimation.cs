using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]private Transform _playerTransform;


    public string[] StaticAnimations = { "Static N", "Static NO", "Static O", "Static SO", "Static S", "Static SE", "Static E", "Static NE" };
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayerBoatAnimation()
    {
        if (_playerTransform.rotation.eulerAngles.z < 30f || _playerTransform.rotation.eulerAngles.z > 315f)
        {
            _animator.SetFloat("velX", 0f);
            _animator.SetFloat("velZ", 1f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 55f && _playerTransform.rotation.eulerAngles.z > 30f)
        {
            _animator.SetFloat("velX", 0.5f);
            _animator.SetFloat("velZ", 0.5f);
        }
        else  if (_playerTransform.rotation.eulerAngles.z < 105f && _playerTransform.rotation.eulerAngles.z > 75f)
        {
            _animator.SetFloat("velX", 1f);
            _animator.SetFloat("velZ", 0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 150f && _playerTransform.rotation.eulerAngles.z > 105f)
        {
            _animator.SetFloat("velX", 0.5f);
            _animator.SetFloat("velZ", -0.5f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 195f && _playerTransform.rotation.eulerAngles.z > 150f)
        {
            _animator.SetFloat("velX", 0f);
            _animator.SetFloat("velZ", -0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 240f && _playerTransform.rotation.eulerAngles.z > 195f)
        {
            _animator.SetFloat("velX", -0.5f);
            _animator.SetFloat("velZ", -0.5f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 290f && _playerTransform.rotation.eulerAngles.z > 240f)
        {
            _animator.SetFloat("velX", -1f);
            _animator.SetFloat("velZ", 0f);
        }
        else if (_playerTransform.rotation.eulerAngles.z < 315f && _playerTransform.rotation.eulerAngles.z > 290f)
        {
            _animator.SetFloat("velX", -0.5f);
            _animator.SetFloat("velZ", 0.5f);
        }
    }
}
