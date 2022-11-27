using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> _levelConfigs;
    
    public void LoadMainMenuScene()
    {
        MainMenu.Load();    
    }
    
    public void LoadMainScene(int id)
    {
        MainScene.Load(_levelConfigs[id]);
    }

    public void LoadLevelSelectScene()
    {
        LevelSelect.Load();
    }

    public void LoadVictoryScene()
    {
        VictoryScene.Load();
    }

    public void LoadTimeOverScene()
    {
        TimeOverScene.Load();
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    
}
