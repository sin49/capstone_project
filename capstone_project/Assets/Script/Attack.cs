using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Shoot;
    // Start is called before the first frame update
    private float attackCoolTime;
    private float timer;

    private void Start()
    {
        attackCoolTime = 0.1f ;
        timer = 0f ;
    }

    // Update is called once per frame
    void Update()
    {

        ShootAttack();
    }

    void ShootAttack()
    {
        timer += Time.deltaTime;

        if (timer >= attackCoolTime)
        {

            if (Input.GetKey(KeyCode.A))
            {
                ShootBullet();
            }
            timer = 0;

        }
       
    }

    void ShootBullet()
    {
        var myInstance = ObjectPool.GetObject(Shoot.transform);
       
    }
}
