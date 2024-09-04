using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoiaMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _deltaX, _deltaY;
    private Vector3 _startPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position*-1);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    _deltaX = touchPos.x - transform.position.x;
                    _deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    _rb.MovePosition(new Vector2(touchPos.x - _deltaX, touchPos.y - _deltaY));
                    break;

                case TouchPhase.Ended:
                    _rb.velocity = Vector2.zero;
                    transform.position = _startPos;
                    break;


            }
        }
    }
}
