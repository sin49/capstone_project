using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public PlayerCharacter p_chr;
    public GameObject prefab;
    public GameObject Gun;
    public GameObject Shoot;
    public bool Dan = true;
 
    private float attackCoolTime;
    private float timer;

    private void Start()
    {
        attackCoolTime = 0.1f ;
        timer = 0f ;
        p_chr = this.gameObject.GetComponent<PlayerCharacter>();
    }
    private void FixedUpdate()
    {
        if (!p_chr.death_check)
            MouseAttack();
    }
    
   

    void MouseAttack()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Gun.transform.rotation = rotation;

        if (Dan)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= timer)
                {
                    ShootBullet(Gun, Shoot, p_chr.Attack_point);
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
                    ShootBullet(Gun, Shoot,p_chr.Attack_point);
                    timer = Time.time + attackCoolTime;
                }
            }
        }
    }

    void ShootBullet(GameObject Gun,GameObject Shoot,int damage)
    {
        Gun.transform.rotation = Gun.transform.rotation;
        var myInstance = ObjectPool.GetObject(Gun.transform,Shoot.transform,damage);
       
    }
}
