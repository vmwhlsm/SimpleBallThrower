using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class GameManager : MonoBehaviour, ISceneLoadHandler<LevelConfig>
{
    [SerializeField] private Rim _rim;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private MenuController _menuController;
    [SerializeField] private TimeManager _timeManager;
    
    
    public void OnSceneLoaded(LevelConfig argument)
    {
        _timeManager.SetTime(argument.TimeSec);
        _scoreCounter.SetGoal(argument.Goal);
    }
    
    void Start()
    {
        _rim.Goaled += _scoreCounter.IncreaseScore;
        _timeManager.TimeLeft += _menuController.LoadTimeOverScene;
        _scoreCounter.GoalRiched += _menuController.LoadVictoryScene;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuController.LoadMainMenuScene();
        }        
    }

    private void OnDestroy()
    {
        _rim.Goaled -= _scoreCounter.IncreaseScore;
        _timeManager.TimeLeft -= _menuController.LoadTimeOverScene;
        _scoreCounter.GoalRiched -= _menuController.LoadVictoryScene;
    }

    
}
