using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFeedBack : MonoBehaviour
{
    [Header("ImageFeedBackAccelerating")]
    [SerializeField] private Sprite _upPressed;
    [SerializeField] private Sprite _upUnpressed;
    [SerializeField] private Image _upIMG;  
    
    [Header("ImageFeedBackRescuing")]
    [SerializeField] private Sprite _upPressedRescuing;
    [SerializeField] private Sprite _upUnpressedRescuing;
    [SerializeField] private Image _upIMGRescuing;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Player._accelerating += ButtonsFeedBackAccelerating;
        Rescue._rescuing += ButtonsFeedBackRescuing;
    }
    private void OnDisable()
    {
        Player._accelerating -= ButtonsFeedBackAccelerating;
        Rescue._rescuing -= ButtonsFeedBackRescuing;
    }
    // Update is called once per frame

    private void ButtonsFeedBackAccelerating(bool isPressed)
    {
        if (isPressed)
        {
            _upIMG.sprite = _upPressed;
        }
        else
        {
            _upIMG.sprite = _upUnpressed;
        }
    }
    private void ButtonsFeedBackRescuing(bool isPressed)
    {
        Debug.Log("ahhhhh");
        if (isPressed)
        {
            _upIMGRescuing.sprite = _upPressedRescuing;
        }
        else
        {
            _upIMGRescuing.sprite = _upUnpressedRescuing;
        }
    }
}
