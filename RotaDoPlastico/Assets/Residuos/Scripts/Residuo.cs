using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residuo : MonoBehaviour
{
    private Collider2D _circleCollider;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameManager.PassResiduo();
            Destroy(gameObject);
        }
    }
}
