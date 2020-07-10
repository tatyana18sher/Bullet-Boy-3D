using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;

   public void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }
}
