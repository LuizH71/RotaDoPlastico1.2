using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _time;

    [HideInInspector] public bool TimeEnded;
    private bool DoOnce = false;


    private void Awake()
    {
        DoOnce = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(_time > 0)
        {
            _time -= Time.deltaTime;
        }
        else if (!DoOnce && _time < 0)
        {
            TimeEnded = true;
            DoOnce = true;
        }

 
        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = Mathf.FloorToInt(_time % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
