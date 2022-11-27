using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeUi;

    private float _time;

    public event UnityAction TimeLeft;

    private void Update()
    {
        _time -= Time.deltaTime;
        _timeUi.text = $"{Convert.ToString(Convert.ToInt32(_time) / 60)}:{Convert.ToString(Convert.ToInt32(_time) % 60)}";
        
        if (_time <= 0)
        {
            TimeLeft?.Invoke();
        }
    }

    public void SetTime(int time)
    {
        _time = time;
    }
}
