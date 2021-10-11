using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    int Health_point;//채력
    protected float Attack_point;//공격력
    int Defense_point;//방어력 최대수치 100
    bool can_attacked;//1=공격받을수있다 0=공격받을수없다
    bool can_ataack;//1=공격할수있다 0=공격할수없다
    public float move_speed=1.0f;//이동속도
    public float jump_force=30.0f;//점프높이
    
    int direct;//캐릭터의 방향 1, -1 만 허용
    
    void Start()
    {
        //Rigidbody2D rgd = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Defense_point > 100)
            Defense_point = 100;
    }
    void character_lose_health(GameObject obj)//obj=공격 오브젝트 피격시 체력을 잃는 계산식
    {
        if (can_attacked)
        {
            GameCharacter gamecharacter_ = obj.GetComponent<GameCharacter>();
            float damage_lose = Defense_point / 100;
            int damage = Mathf.RoundToInt(gamecharacter_.Attack_point * (1.0f - damage_lose));//데미지 계산식
            if (damage == 0)
            {
                damage = 1;
            }
            Health_point = Health_point - damage;//체력을 데미지만큼 감소
        }
    }
    public void character_move()//캐릭터 이동 상속용
    {
       /* Vector3 move_force = new Vector3(move_speed * direct, 0, 0);
        rgd.AddForce(move_force);
        RaycastHit hit;
        Debug.DrawRay(chr_eye1.transform.position, new Vector3(0.1f, -0.9f, 0), Color.blue);
        if (Physics.Raycast(chr_eye1.transform.position, new Vector3(0.1f, -0.9f, 0), out hit, 2))
        {
            if (hit.collider.CompareTag("platform"))
                direct = direct * -1;
        }
        //if(XXXXXX)//자신의 앞을 확인하고 떨어진다면
        /*direct= direct*-1;
         * 
         */
    }//기본 이동은 플랫폼에 안떨어지고 좌우 왔다갔다 움직임
    //광선으로 처리하면 크기마다 달라지니 힘들다? ->시작 지점을 정하면 고정가능

    void character_death()//상속용
    {
        //필요한 이벤트를 작성
        
    }
    /*void jump()//점프 상속
    {
        /*if (jump_number != 0)
        {
          

            Vector3 jump_vector = new Vector3(0, jump_force, 0);
            rgd.AddForce(jump_vector);
        }*/
    //}
    

}
/*캐릭터가 플랫폼에 안떨어지려면...
 캐릭터에게 "눈"을 달자
 "눈"은 캐릭터 외부에 충돌영역으로 존재
 "눈"은 안떨어지는 용도외에 캐릭터가 점프를 하거나 캐릭터를 쫓는 등 여러 활용도를 가진다
 캐릭터의"눈"은 하나가 아니다->용도에따라 여러 충돌영역을 만들어야 한다
 충돌영역이 아니라 제작에 따라 ray(광선)으로도 제작 가능
 */

/*풀링 시스템
 총알을 비활성화 시켜놓고
 공격키-> 총알을 위치로 이동시켜놓고 활성화
 닿거나 화면 밖으로 나가면 비활성화
 총알 태그=bullet
 */
