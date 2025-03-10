using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroPlasticComponent : MonoBehaviour
{

    private bool _collided = false;
    private GameObject _player;
    private MicroPlasticArea _parent;

    [SerializeField] private UnityEvent _colected;
    private void Start()
    {
        //_parent = gameObject.GetComponentInParent<MicroPlasticArea>();
    }

    private void Update()
    {
        /*
        if (_collided)
        {
            float step = 5 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);

            float t = 1f * Time.deltaTime;
            transform.localScale = new Vector3(Mathf.Lerp(1, 0.2f, t), Mathf.Lerp(1, 0.2f, t), 0);

            if (Vector3.Distance(transform.position, _player.transform.position) < 0.1f)
            {
                Destroy(gameObject);

            }
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rede"))
        {
            Destroy(gameObject);
            _collided = true;
            _player = collision.gameObject;
            Destroy(gameObject);
            _colected.Invoke();
        }
    }
}
