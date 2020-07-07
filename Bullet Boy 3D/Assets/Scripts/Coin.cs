using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Unit
{
     public AudioSource coinSound;
    void Update()
    {
        transform.Rotate(new Vector3(0,40,0) * Time.deltaTime);
        
    }

    void OnTriggerEnter(Collider collider)
     {
          if (collider.CompareTag("Bullet"))
         {  
              coinSound.Play();
              Score.scoreAmount += 10;
              Destroy(gameObject);
             
         }

     }


     


    //  protected  void OnTriggerEnter(Collider collider)
    //  {
    //    Bullet bullet = collider.GetComponent<Bullet>();
    //      if (bullet)
    //      {
    //          Score.scoreAmount += 30;   
    //          Destroy (gameObject);
    //      }
        //  Bullet bullet = collider.GetComponent<Bullet>();

        //  if (bullet)
        //  {
        //      Score.scoreAmount += 10;
        //      Destroy(gameObject);
             
        //  }

     //}
}
