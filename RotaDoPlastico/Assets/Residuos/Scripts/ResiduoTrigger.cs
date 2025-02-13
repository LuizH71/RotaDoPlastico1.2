using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResiduoTrigger : MonoBehaviour
{
    [SerializeField] public Residuo ResiduoSO;

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
        }
    }
}
