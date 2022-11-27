using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Level Config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _timeSec;
    [SerializeField] private int _goal;
    
    public int TimeSec => _timeSec;
    public int Goal => _goal;
}
