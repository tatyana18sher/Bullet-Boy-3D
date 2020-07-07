using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;

   public void Start()
   {
    //    if(SceneManager.GetActiveScene().buildIndex == 0)
    //     {  
    //         audioSource = gameObject.AddComponent<AudioSource>();
    //         audioSource.playOnAwake = false;
    //     }
   } 
   public void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }
}
