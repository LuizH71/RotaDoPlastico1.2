using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private Player _player;
    [SerializeField] private bool left = false;
    [SerializeField] private bool right = false;
    [SerializeField] private bool up = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (left)
        {
            _player.left = true;
        }
        else if (right)
        {
            _player.right = true;
        }
        else if (up)
        {
            _player._isAccelerating = true;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (left)
        {
            _player.left = false;
        }
        else if (right)
        {
            _player.right = false;
        }
        else if (up)
        {
            _player._isAccelerating = false;
        }
    }
}
