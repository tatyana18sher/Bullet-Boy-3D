using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
  private GameObject parent;
    public GameObject Parent { set {parent = value; } get { return parent;} }
    private float speed = 100.0F; // скорость пули
    private Vector3 direction; // направление пули

    //private Vector3 enemyPos;

  

    //public Monster monster;


    private SpriteRenderer sprite;

    //	public static int sceneNumber = 0;

   


    //public bool teleported = false;
	//public Bullet target;

    public Vector3 Direction // создаём свойство, чтобы дать доступ полю направления пули
    {
        set { direction = value; }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Box"))
        {  
           
            Application.LoadLevel(Application.loadedLevel);
            //sceneNumber--;
             //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);   
           // SceneManager.LoadScene();
            Destroy(gameObject);
           
        }

        if (collider.CompareTag("RobotKyle"))
        {
            Destroy(gameObject);

        }
        

        if (collider.CompareTag("Enemy"))
        {
            GameObject.Find("char_shadow").transform.position += new Vector3(0, 0, 9);
            Destroy(gameObject);
            Score.scoreAmount += 50;
            PlayerPrefs.SetInt("Score", Score.scoreAmount);

            //collider.transform.position = player.transform.position; 
        }

        // if (collider.CompareTag("Enemy"))
        // {
        //     player.transform.Z(15f);
        // }

        // if (collider.CompareTag("Coin"))
        // {  
        //     Score.scoreAmount += 10;
        // }
    //    if (collider.CompareTag("Enemy"))
    //     {  
	// 		if (!teleported)
	// 		{
	// 			target.teleported = true;
	// 			collider.gameObject.transform.position = target.gameObject.transform.position;
	// 		}
	// 	}

        

       
            

    }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {      
        Destroy(gameObject, 4F);  

       
    }
    
     
   //public Vector3 teleportPosition;
    void Update()
    {

        // RaycastHit hit;
        // Ray ray;
        // ray = Camera.main.ScreenPointToRay(new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y));
        //     if (Physics.Raycast(ray, out hit, 10000))
        //     {
        //         if (hit.collider.gameObject.name == "Enemy")
        //         {
        //             transform.position = teleportPosition;
        //         }
        //     }



        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // метод для движения
    }

    //Уничтожить пулю, если она вылетела за экран (out of screen)
    void OnBecameInvisible ()
    {
       Destroy(gameObject);
    }
}
