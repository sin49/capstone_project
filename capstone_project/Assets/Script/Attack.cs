using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Gun;
    public GameObject Shoot;
    public bool Dan = true;
    private float attackCoolTime;
    private float timer;
    Quaternion mouse_rotation;
    public Vector2 direction;
    private void Start()
    {
        attackCoolTime = 0.1f ;
        timer = 0f ;
        
    }
    private void FixedUpdate()
    {
<<<<<<< HEAD
        mouse_point();
        if (!p_chr.death_check)
        {
            MouseAttack();
        }
    }
    void mouse_point()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        mouse_rotation = Quaternion.AngleAxis(angle, Vector3.forward);
=======
        MouseAttack();
>>>>>>> 1cecacbbde3a387f8e8be4a32fa6b44c6e2d697b
    }
   

    void MouseAttack()
    {
        
        Gun.transform.rotation = mouse_rotation;

        if (Dan)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= timer)
                {
                    ShootBullet(Gun, Shoot);
                    timer = Time.time + attackCoolTime;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time >= timer)
                {
                    ShootBullet(Gun, Shoot);
                    timer = Time.time + attackCoolTime;
                }
            }
        }
    }
<<<<<<< HEAD
   
    void ShootBullet(GameObject Gun,GameObject Shoot,int damage)
=======

    void ShootBullet(GameObject Gun,GameObject Shoot)
>>>>>>> 1cecacbbde3a387f8e8be4a32fa6b44c6e2d697b
    {
        Gun.transform.rotation = Gun.transform.rotation;
        var myInstance = ObjectPool.GetObject(Gun.transform,Shoot.transform);
       
    }
}
