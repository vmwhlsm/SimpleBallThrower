using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _scoreUI;
   
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
   }
}
