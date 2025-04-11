using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private static Rescue _rescue;

    [Header("Boat Parameters")]
    [SerializeField] private float _boatAcceleration = 10f;
    [SerializeField] private float _boatMaxVelocity = 10f;
    [SerializeField] private float _boatRotatioSpeed = 100f;

    private Rigidbody2D _rb;
    public bool _isAccelerating = false;

    public bool left = false;
    public bool right = false;

    private AudioSource _audioSource;

    [SerializeField] private PlayerAnimation _playerAnimation;

    public static UnityAction<bool> _accelerating;// Cria uma ação/event que passa um bool. Esse evento é especialmente
    // para a classe, ButtonFeedback, com essa informação ele vai saber se o botão na HUD deve estar pressionado ou não
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _rescue = GetComponent<Rescue>();
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
        if (!_rescue.Ligado)
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
            _accelerating?.Invoke(_isAccelerating);// Chama o Evento
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
        _playerAnimation.PlayerBoatAnimation();
    }

    public void StopAccelerating()
    {
        _isAccelerating = false;
        _audioSource.enabled = false;
        left = false;
        right = false;
    }
}
