using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpDialogue : MonoBehaviour
{

    [SerializeField] private TextInteraction _interaction;

    [SerializeField] private float _timeToHold;
    private float _holdedTime;
    private bool _holding = false;

    [Header("UI Elements")]
    [SerializeField] private Slider _slider;
    private void Update()
    {
        TouchHold();
        PassTime();
    }
    private void PassTime()
    {
        if (_holding)
        {
            _holdedTime += Time.deltaTime;
            _slider.value = _holdedTime;
            if(_holdedTime >= _timeToHold)
            {
                _interaction.EndConversation();
                _interaction.gameObject.SetActive(false);
                _slider.gameObject.SetActive(false);
            }
            else if (_holdedTime > 0.1f)
            {
                _slider.gameObject.SetActive(true);
            }
        }
    }
    private void TouchHold()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _holding = true;

                    break;

                case TouchPhase.Ended:
                    _holding = false;
                    _holdedTime = 0;
                    _slider.gameObject.SetActive(false);
                    break;
            }


        }
    }
}
