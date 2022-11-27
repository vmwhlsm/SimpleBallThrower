using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _scoreUI;
   [SerializeField] private TextMeshProUGUI _goalUI;

   private int _goal;
   
   public event UnityAction GoalRiched;
   
   public int Score { get; private set; }

   void Start()
   {
      Score = 0;
      _scoreUI.text = Convert.ToString(Score);
   }

   public void IncreaseScore()
   {
      Score++;
      _scoreUI.text = Convert.ToString(Score);

      if (Score >= _goal)
         GoalRiched?.Invoke();
   }

   public void SetGoal(int goal)
   {
      _goal = goal;
      _goalUI.text = Convert.ToString(goal);
   }
}
