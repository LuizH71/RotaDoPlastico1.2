using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent BoatHit; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Terreno"))
        {
            BoatHit.Invoke();
        }
    }
}
