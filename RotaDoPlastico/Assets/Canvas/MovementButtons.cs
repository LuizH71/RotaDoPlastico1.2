using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private Player _player;
    private Rescue _playerRescue;
    [SerializeField] private bool left = false;
    [SerializeField] private bool right = false;
    [SerializeField] private bool up = false;
    [Tooltip("Variavel que faz a boia retornar ao barco")]
    [SerializeField] private bool Return = false;


    [Header("ImageFeedBack")]
    [SerializeField] private Sprite _upPressed;
    [SerializeField] private Sprite _upUnpressed;
    [SerializeField] private Image _upIMG;

    // Start is called before the first frame update
    void Start()
    {
        _player = Player.Instance;
        _playerRescue = _player.GetComponent<Rescue>();
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
        else if (Return)
        {
            _playerRescue.Return = true;
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
        else if (Return)
        {
            _playerRescue.Return = false;
        }
    }
}
