using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

     public AudioSource shootSound;
     public int Level;
     int sceneIndex;


   void OnTriggerEnter(Collider collider)
     {
          if (collider.CompareTag("Bullet"))
         {  
              shootSound.Play();
              Score.scoreAmount += 50;
               PlayerPrefs.SetInt("Score", Score.scoreAmount);
        
             if(SceneManager.GetActiveScene().buildIndex == 0)
             {
              SceneManager.LoadScene("2");
             }
             if(SceneManager.GetActiveScene().buildIndex == 1)
             {
              SceneManager.LoadScene("3");
             }
             if(SceneManager.GetActiveScene().buildIndex == 2)
             {
              SceneManager.LoadScene("4");
             }
             if(SceneManager.GetActiveScene().buildIndex == 3)
             {
              SceneManager.LoadScene("1");
             }
              
             
         }

     }
   
}
