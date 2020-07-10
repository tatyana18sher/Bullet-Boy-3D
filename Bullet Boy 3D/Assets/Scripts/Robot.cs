using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public AudioSource shootSound;

    void OnTriggerEnter(Collider collider)
     {
         if (collider.CompareTag("Bullet"))
         {  
            shootSound.Play();
            Destroy(gameObject);

         }
     }
}
