using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerCharacter p_chr;
    public GameObject prefab;
    public GameObject Gun;
    public GameObject Shoot;
    Quaternion mouse_rotation;
    public Vector2 direction;

   

    private bool FireState; // 미사일 발사 속도를 제어할 변수

    private void Start()
    {
        p_chr = this.gameObject.GetComponent<PlayerCharacter>();
        FireState = true;
    }
    private void FixedUpdate()
    {
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
        MouseAttack();
    }


    void MouseAttack()  //공격 버튼 처리
    {
        
        Gun.transform.rotation = mouse_rotation;

        if (Player_status.p_status.get_volly())
        {
            if (FireState)
            {
                if (Input.GetMouseButton(0))
                {
                    StartCoroutine(FireCycleControl());
                    ShootBullet(Gun, Shoot,Player_status.p_status.get_atk(), Player_status.p_status.get_bullet_speed());
                }
            }
        }
        else
        {
            if (FireState)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShootBullet(Gun, Shoot, Player_status.p_status.get_atk(), Player_status.p_status.get_bullet_speed());
                }
            }
        }
    }
    void ShootBullet(GameObject Gun,GameObject Shoot,int damage,float speed)    //총 발사
    {
        Gun.transform.rotation = Gun.transform.rotation;
        var myInstance = ObjectPool.GetObject(Gun.transform,Shoot.transform,damage,speed);
    }

    IEnumerator FireCycleControl()
    { // 처음에 FireState를 false로 만들고
        var wait = new WaitForSeconds(Player_status.p_status.get_firedelay());

        FireState = false; // FireDelay초 후에
        yield return wait; //FireState를 true로 만든다.
        FireState = true;
    }

}
