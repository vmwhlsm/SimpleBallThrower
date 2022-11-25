using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rim _rim;
    [SerializeField] private ScoreCounter _scoreCounter;
    
    void Start()
    {
        _rim.Goaled += _scoreCounter.IncreaseScore;
    }

    private void OnDestroy()
    {
        _rim.Goaled -= _scoreCounter.IncreaseScore;
    }
}
