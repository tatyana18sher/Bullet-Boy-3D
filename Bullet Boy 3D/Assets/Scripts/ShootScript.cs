using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Bullet;

    public float LaunchForce;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, transform.position, transform.rotation);

        BulletIns.GetComponent<Rigidbody>().velocity = transform.right * LaunchForce;

    }
}
