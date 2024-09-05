using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _deltaX, _deltaY;
    private Vector3 _startPos;
    private GameObject _player;

    [SerializeField] private float _rayRadius;

    [HideInInspector] public bool LaunchBoia;

    [SerializeField] private LayerMask TerrnoAndPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();

        TargetMovement();
    }

    private void TargetMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position * -1);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _deltaX = touchPos.x - transform.position.x;
                    _deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    _rb.MovePosition(new Vector2(touchPos.x - _deltaX, touchPos.y - _deltaY));
                    break;

                case TouchPhase.Ended:
                    if (!LaunchBoia)
                    {
                        ResetPos();
                    }
                    else
                    {
                        _rb.velocity = Vector2.zero;
                        _player.GetComponent<Rescue>().SpawnBoia();
                        _player.GetComponent<Rescue>().Launch = true;
                        this.enabled = false;
                    }
                    break;


            }
        }
    }


    public void ResetPos()
    {
        transform.position = _startPos;
        this.enabled = true;
    }
    private void Raycast()
    {

        if (Physics2D.CircleCast(transform.position, _rayRadius, Vector2.zero,1f,TerrnoAndPlayer))
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            LaunchBoia = false;

        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            LaunchBoia = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _rayRadius);

    }
}
