using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : Unit
{
    

    public static int scoreAmount = 0; // переменная, содержащая кол очков
    public Text scoreText;
   
    
    private void Start()
    { 
        scoreText = GetComponent<Text>();    
        scoreAmount = PlayerPrefs.GetInt("Score");  
    }

  
    private void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
