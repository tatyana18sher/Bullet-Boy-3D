using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    // Vector2 Direction;

    // public float force;

    // public GameObject PointPrefab;

    // public GameObject[] Points;

    // public int numberOfpoints;

    // void Start()
    // {
    //     Points = new GameObject[numberOfpoints];

    //     for(int i = 0; i < numberOfpoints; i++)
    //     {
    //         Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
    //     }

    // }

    // void Update()
    // {
    //     Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //     Vector2 gunPos = transform.position;

    //     Direction = MousePos - gunPos;

    //     faceMouse();

    //     for (int i = 0; i < Points.Length; i++)
    //     {
    //         Points[i].transform.position = PointPosition(i * 0.1f);
    //     }
    // }

    // void faceMouse()
    // {
    //     transform.right = Direction;
    // }

    // Vector2 PointPosition(float t)
    // {
    //     Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t*t);

    //     return currentPointPos;
    // }










    // public Transform bullet; // сама переменная нашей пули
	// public int BulletForce = 50; // сила, с которой наша пуля будет лететь к цели
	// public int Magaz = 100; // кол патронов в магазине
	// //public AudioClip Fire; // аудиоклип выстрела
	// //public AudioClip Reload; // перезарядки
    // //public TrajectoryRenderer Trajectory;

   


   

	// void Update () {
	// 	if (Input.GetMouseButtonDown (0) & Magaz > 0) { // при нажатии левой кнопки миши
    //          Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("Spawn").transform.position, Quaternion.identity);// происходит spawn пули в точке spawn
	// 		BulletInstance.GetComponent<Rigidbody> ().AddForce (transform.forward * BulletForce); // включается rigidbody с Force, двигается вперёд и * на силу полёта пули
	// 		Magaz = Magaz - 1; // кол патронов в магазине уменьшается на 1
	// 		//GetComponent<AudioSource> ().PlayOneShot (Fire);
	// 		//GetComponent<AudioSource> ().PlayOneShot (Reload);
         
    //        // Trajectory.ShowTrajectory(transform.position, speed);

	// 	}
	// 	// if (Input.GetKeyDown (KeyCode.R)) {
	// 	// 	Magaz = 7;
		
	// 	// }
	// }








    ///////////////////////////////////////////////////////////////////////////////////////

   public Transform BulletPrefab;
    public float Power = 5000;

    public TrajectoryRenderer Trajectory;
    //public TrajectoryRendererAdvanced Trajectory;

    //private Camera mainCamera;

  //  float startX = 0;

  float rotationSpeed = 500;
  //bool swipe = false;
  //float startXPos = 0;

  private float gravityScale = 1;

  private float gravityScaleZ = 0;


    bool swipe = false;
     float startXPos = 0;


 


   // float range = 0;
   // private Vector3 worldPos=new Vector3(0,0);
    //public float mouse_sens = 2f;
   // private GameObject weapon;
    
    private void Start()
    {
       // mainCamera = Camera.main;

        // rotationSpeed = settings.instance.rotationSpeed;

       // weapon = GetComponent<Rigidbody>();

      // rotationSpeed = settings.instance.rotationSpeed;
       


        
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

        gravityScaleZ += Input.GetAxis("Mouse Y") / 5;
           
        }
      }
    }
    else
    {
     if (Input.GetMouseButton(0))
       {
       
        //Power += Input.GetAxis("Mouse Y") / 10;

        speed = transform.forward * (Power/5);

        Trajectory.ShowTrajectory(GameObject.Find("Spawn").transform.position, speed);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime);
        
        gravityScale = transform.rotation.y*(-5);

        gravityScaleZ += Input.GetAxis("Mouse Y") / 5;
       }
           

      }
    }


    
     void Update()
    {
        
       // Vector3 speed = new Vector3(0,0,0);

       //worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
       Rotate();

       


        // if (!Input.GetMouseButtonDown(0))
        // {
        //     startX = worldPos.x;


        // }
        //if (Input.GetMouseButtonDown(0))
       // {
           // transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + worldPos.x, transform.rotation.z );  
            
        //     startX = worldPos.x;
           //  range = startX - worldPos.x;
         // transform.rotation = Quaternion.Euler(transform.rotation.x, worldPos.x, transform.rotation.z );
        //}

        
        //     float enter;
        // Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
    
        //  Vector3 mouseInWorld = ray.GetPoint(enter);
        //  speed = (mouseInWorld - transform.position) * Power;
         //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
        // Сохраняем координаты указателя мыши
        
        //float dy = this.transform.position.y - worldPos.y;

      //  Power =  Camera.main.ScreenToWorldPoint(Input.mousePosition).y/(-5);

      
        //speed = transform.forward * (Power/5);

        
        
        

        
        if (Input.GetMouseButtonUp(0))
        {
            //Rigidbody bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //bullet.AddForce(speed, ForceMode.VelocityChange);
            //float angel = transform.rotation.y * Mathf.Deg2Rad;
            //bullet.AddForce(new Vector3(5 * Mathf.Sin(angel), -5 * Mathf.Cos(angel), 0), ForceMode.Force);

            Transform BulletInstance = (Transform)Instantiate(BulletPrefab, GameObject.Find("Spawn").transform.position, Quaternion.identity);
	 		BulletInstance.GetComponent<Rigidbody>().AddForce (transform.forward * Power * Power); 


              
        }

         
       

      

     
             


      Physics.gravity = new Vector3(gravityScale, 0, gravityScaleZ);

    

  
    }
}
    



   
  



