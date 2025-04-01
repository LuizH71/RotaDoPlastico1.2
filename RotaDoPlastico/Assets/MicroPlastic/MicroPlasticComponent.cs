using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroPlasticComponent : MonoBehaviour
{

    [SerializeField] private UnityEvent _colected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rede"))
        {
            Destroy(gameObject);
            _colected.Invoke();
        }
    }
}
