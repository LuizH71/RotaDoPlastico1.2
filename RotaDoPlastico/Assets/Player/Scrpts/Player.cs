using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [Header("Boat Parameters")]
    [SerializeField] private float _boatAcceleration = 10f;
    [SerializeField] private float _boatMaxVelocity = 10f;
    [SerializeField] private float _boatRotatioSpeed = 100f;

    private Rigidbody2D _rb;
    public bool _isAccelerating = false;

    public bool left = false;
    public bool right = false;

    private AudioSource _audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleShipRotations();
        //HandleBoatAcceleration();
    }
    private void FixedUpdate()
    {
        if (_isAccelerating)
        {
            _rb.AddForce(_boatAcceleration * transform.up);
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _boatMaxVelocity);
        }
    }
    public void Accelerate()
    {
        if (_isAccelerating)
        {
            _isAccelerating = false;
            _audioSource.enabled = false;
        }
        else
        {
            _isAccelerating = true;
            _audioSource.enabled = true;
        }

    }


    private void HandleShipRotations()
    {
        //boat rotation
        if (left)
        {
            transform.Rotate(_boatRotatioSpeed * Time.deltaTime * transform.forward);
        }
        else if (right)
        {
            transform.Rotate(-_boatRotatioSpeed * Time.deltaTime * transform.forward);
        }
    }

}
