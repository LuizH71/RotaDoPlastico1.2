using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFeedBack : MonoBehaviour
{
    [Header("ImageFeedBack")]
    [SerializeField] private Sprite _upPressed;
    [SerializeField] private Sprite _upUnpressed;
    [SerializeField] private Image _upIMG;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Player._accelerating += ButtonsFeedBack;
    }
    private void OnDisable()
    {
        Player._accelerating -= ButtonsFeedBack;
    }
    // Update is called once per frame

    private void ButtonsFeedBack(bool isAccelerating)
    {
        Debug.Log("ahhhh");
        if (isAccelerating)
        {
            _upIMG.sprite = _upPressed;
        }
        else
        {
            _upIMG.sprite = _upUnpressed;
        }
    }
}
