using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
  private GameObject parent;
    public GameObject Parent { set {parent = value; } get { return parent;} }
    private float speed = 500; // скорость пули
    private Vector3 direction; // направление пули


    private SpriteRenderer sprite;

    private int number = 0;


    private void Start()
    {      
        Destroy(gameObject, 4F);     
    }

   
	

    public Vector3 Direction // создаём свойство, чтобы дать доступ полю направления пули
    {
        set { direction = value; }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag("Box"))
        {      
            Application.LoadLevel(Application.loadedLevel);
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
            Weapon.setGravityOn(true);
            

        }

        if (collider.CompareTag("Robot"))
        {
            Score.scoreAmount += 50;
            PlayerPrefs.SetInt("Score", Score.scoreAmount);
            number++;
        }

        if (collider.CompareTag("Box1"))
        {
            number++;
            if(number == 2) {SceneManager.LoadScene("1");}
            
        }
        

         
   

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Final"))
        {
            Application.LoadLevel(Application.loadedLevel);
        
        }
    }
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    
    
     

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // метод для движения
    }


  
}
