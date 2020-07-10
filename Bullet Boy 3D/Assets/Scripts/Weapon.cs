using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Weapon : MonoBehaviour
{
 

   public Transform BulletPrefab;
    public float Power = 5000;

    public TrajectoryRenderer Trajectory;
  

  float rotationSpeed = 200;
  

  private float gravityScale = 1;



  private static bool gravityOn;


    bool swipe = false;
     float startXPos = 0;






    public static void setGravityOn(bool x) {
      gravityOn = x;
    }
    
    private void Start()
    {
      Time.timeScale = 2;
      gravityOn = true;
    }

    private void Awake()
    {
        Resources.Load<Bullet>("Bullet"); 
    }


     void Rotate()
    {
        
        Vector3 speed = new Vector3(0,0,0);
    if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
    {

      if (Input.touchCount == 1)
      {
        if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
          startXPos = Input.GetAxis("Mouse X");
          swipe = true;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
          swipe = false;
        }

        if (swipe)
        {
           speed = transform.forward * (Power/5);

        Trajectory.ShowTrajectory(GameObject.Find("Spawn").transform.position, speed);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime);
        
        gravityScale = transform.rotation.y*(-5);

       
           
        }
      }
    }
    else
    {
     if (Input.GetMouseButton(0) && gravityOn)
       {
         
       

        speed = transform.forward * (Power/5);

        Trajectory.ShowTrajectory(GameObject.Find("Spawn").transform.position, speed);

        if (transform.rotation.y < 45 && transform.rotation.y > -45)
        {

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime);
        }
        gravityScale = transform.rotation.y*(-3);

       }
       
           

      }
    }


    
     void Update()
    {
      Rotate();

      if (Input.GetMouseButtonUp(0) && gravityOn)
        {
          Transform BulletInstance = (Transform)Instantiate(BulletPrefab, GameObject.Find("Spawn").transform.position, Quaternion.identity);
	 		    BulletInstance.GetComponent<Rigidbody>().AddForce (transform.forward * Power * Power); 

          gravityOn = false;
     
        }

   
      Physics.gravity = new Vector3(gravityScale, 0, 0);


  
    }
}
    



   
  



