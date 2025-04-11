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
    public bool StartTimer = false;

    public static Timer Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DoOnce = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (StartTimer && !TimeEnded)
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
            }
            else if (!DoOnce && _time < 0)
            {
                TimeEnded = true;
                DoOnce = true;
                GameManager.Instance.FailGame();
            }
            int minutes = Mathf.FloorToInt(_time / 60);
            int seconds = Mathf.FloorToInt(_time % 60);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }



    }
}
