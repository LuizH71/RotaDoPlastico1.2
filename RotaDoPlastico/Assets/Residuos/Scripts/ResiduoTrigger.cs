using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class ResiduoTrigger : MonoBehaviour
{
    [SerializeField] public Residuo ResiduoSO;


    public UnityEvent _gameEvent;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ResiduoCanvas.Instance.PassResToCanvas(ResiduoSO._residuoInfo, ResiduoSO._residuoImage);
            GameManager.Instance.PassResiduo();
            Destroy(gameObject);

            _gameEvent.Invoke();
        }
    }
}

