using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
public class MenuController : MonoBehaviour
{
    public void LoadMainScene()
    {
        MainScene.Load();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
