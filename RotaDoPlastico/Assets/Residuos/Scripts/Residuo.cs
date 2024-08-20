using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Residuo : MonoBehaviour
{
    private ResiduoCanvas _residuoCanvas;
    private Collider2D _circleCollider;
    private GameManager _gameManager;

    [SerializeField] private Sprite _resImage;
    [TextArea]
    [SerializeField] private string _resInfo;
    private void Start()
    {
        _residuoCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ResiduoCanvas>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _gameManager.PassResiduo();
            _residuoCanvas.PassResToCanvas(_resInfo, _resImage);
            Destroy(gameObject);
        }
    }
}
