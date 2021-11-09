using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : GameCharacter
{
    Rigidbody2D rgd;
    int jump_count = 1;
    bool onground;//땅에 닿았는지


    

    Vector3 move_vector;

    [Header("jump")]
     float hangtime = 0.2f;
    float hangTimer;
    float jumpbuffertime = 0.5f;
    float jumpbuffertimer;


    

    [Header("dash input")]
    int dash_count;
    float after_dash_timer;
    float after_dash_timer_check = 0.05f;
    bool dash_recover_check;
    float dash_recover_timer;
    float dash_recover_timer_check = 0.1f;
    bool can_dash = true;
     Vector2 dash_direction;
    float dash_time = 1f;
   float dash_timer = 0;
    bool can_move;
    bool on_dash;
    [SerializeField]
    float move_buffer;
    [SerializeField]
    float move_buffer_timer = 0.2f;

    

    [Header("hitted  input")]
    Vector2 hitted_force;
     float hitted_time = 1f;
    float hitted_timer = 0;
     bool on_hitted;
     Vector2 col_pos;
    bool col_on_room_boost;

    [Header("platform")]
    bool on_platform;
    float Downbuffertime = 0.5f;
    float Downbuffertimer;
    float layer_change_time=0.2f;
    float layer_change_timer;



    public List<ItemClass> get_item = new List<ItemClass>();//현재 아이템 들어가는 곳
    
    void Start()
    {
        Player_status.p_status.set_layout();
        rgd = gameObject.GetComponent<Rigidbody2D>();
        jump_count = Player_status.p_status.get_jump_count();
        direction = 1;
        can_move = true;
    }
    public void set_col_boost(bool a)
    {
        col_on_room_boost = a;
    }
    public bool get_col_boost()
    {
        return col_on_room_boost;
    }
    public void set_can_dash(bool a)
    {
        can_dash = a;
    }
    public void set_can_move(bool a)
    {
        can_move = a;
    }
    void FixedUpdate()
    {
      
        max_hp = Player_status.p_status.get_max_hp();
        Health_point = Player_status.p_status.get_hp();
        Defense_point = Player_status.p_status.get_defense_point();
        move_speed = Player_status.p_status.get_speed();
        //스테이터스의 값 동기화
        
        for(int i = 0; i < get_item.Count; i++)
        {
            if (!get_item[i].get_effecting())
            {
                int a = get_item[i].get_Itemcode();
                Debug.Log(i);
                ItemEffect0.item0to10.effect(a);
                get_item[i].set_effecting_on();
            }
        }
        
        if (!death_check)
        {
            character_move();
            
            if (transform.rotation.y > 360)
                transform.Rotate(0, -360, 0);
            //if(rgd.velocity.y

            //if(rgd.velocity.y
            if (Input.GetButtonDown("Jump"))
            {
                jumpbuffertimer = jumpbuffertime;
            }
            else
            {
                if (jumpbuffertimer > 0)
                {
                    jumpbuffertimer -= Time.deltaTime;
                }
            }
            if (jumpbuffertimer > 0 && jump_count == Player_status.p_status.get_jump_count() && hangTimer > 0)
            {
                jumpbuffertimer = 0;
                minimum_jump();
                //jump();
            }
            else if (jumpbuffertimer > 0 && jump_count != 0)
            {
                jumpbuffertimer = 0;
                minimum_jump();
                //jump();
            }
            if (Input.GetButtonUp("Jump") && rgd.velocity.y > 0)
            {
                jumpbuffertimer = 0;
                rgd.velocity = new Vector2(rgd.velocity.x, rgd.velocity.y * 0.5f);
            }
            if (untouchable_state)
                untouchable();
            if (Health_point <= 0)
                death();
            if (!can_dash)
            {
                after_dash_timer += Time.deltaTime;
                if (after_dash_timer >= after_dash_timer_check)
                {

                    can_dash = true;
                    after_dash_timer = 0;
                }
            }
            if (rgd.velocity.y != 0)
            {
                if (onground)
                {

                    onground = false;
                }
            }
            if (!onground)
            {
                if(hangTimer>0)
                    hangTimer -= Time.deltaTime;
            }
            else
            {
                hangTimer = hangtime;
            }

            if (on_hitted)
            {
                hitted_timer -= Time.deltaTime;
                if (hitted_timer <= 0)
                {
                    hitted_end();
                }
            }
        }
    }
    void dash_recover()
    {
        if (dash_count != Player_status.p_status.get_dash_count())
        {
            dash_recover_timer += Time.deltaTime;
            if (dash_recover_timer >= dash_recover_timer_check)
            {
                dash_count = Player_status.p_status.get_dash_count();
                dash_recover_timer = 0;
            }


        }
    }
    void dash()
    {
        if (Input.GetButtonDown("dash"))
        {
            Debug.Log("대쉬버튼 활성화");
        }
        if (Input.GetButtonDown("dash") && dash_count != 0 && can_dash)
        {
            Debug.Log("대시");
            rgd.velocity = Vector2.zero;
            can_move = false;
            rgd.gravityScale = 0;
            on_dash = true;
            dash_timer = dash_time;
            /*if (p_atk.direction.x >= 0)
            {
                dash_direction = Vector2.right * dash_force;
            }else
            {
                dash_direction = Vector2.left * dash_force;
            }*/
            dash_direction =  Vector2.right*direction * Player_status.p_status.get_dash_force();
            rgd.AddForce(dash_direction *  Time.deltaTime, ForceMode2D.Impulse);
            dash_count--;
            can_dash = false;
            dash_recover_check = false;
        }

    }
    void dash_end()
    {
        rgd.velocity = Vector2.zero;
        can_move = true;
        rgd.gravityScale = 1;
        on_dash =false;
    }
    
    new void character_move()
    {
        //이동속도를 건들 때 move_speed와 velocity.x의 제한값을 건들자
        if (can_move)
        {
            if (Input.GetButton("Right"))
            {
                if (direction == -1)
                {
                    direction_change();
                }
                //move_buffer = move_buffer_timer;
                move_vector = new Vector3(direction * move_speed * Time.deltaTime, 0, 0);
                transform.Translate(move_vector);
            }
            else if (Input.GetButton("Left"))
            {
                if (direction == 1)
                {
                    direction_change();
                }
                //move_buffer = move_buffer_timer;
                move_vector = new Vector3(direction * move_speed * Time.deltaTime * -1, 0, 0);
                transform.Translate(move_vector);
            }
            if (Input.GetButtonDown("Down")&&on_platform&&Downbuffertimer<=0)
            {
                Downbuffertimer = Downbuffertime;
            }
            if (Downbuffertimer > 0)
            {
                Downbuffertimer -= Time.deltaTime;
                if(Input.GetButtonDown("Down") && on_platform && Downbuffertimer >= 0)
                {
                    layer_change_timer = layer_change_time;
                    this.gameObject.layer = 10;
                }
            }
            if (layer_change_timer > 0)
            {
                layer_change_timer -= Time.deltaTime;

            }
            else
            {
                this.gameObject.layer = 6;
            }
        }
        if (!on_dash)
        {
            dash();
        }
        else
        {
            dash_timer -= Time.deltaTime;
            if (dash_timer <= 0)
            {
                dash_end();
            }
        }
        dash_recover();
        /*if (rgd.velocity.x>5)
            rgd.velocity=new Vector2(5,rgd.velocity.y);
        else if (rgd.velocity.x< - 5)
            rgd.velocity = new Vector2(-5, rgd.velocity.y);*/

        /*if (Input.GetButtonUp("Horizontal"))
        {
            rgd.velocity = Vector2.zero;
        }*/
        /*if (!Input.GetButton("Horizontal"))
        {
           
            horiz = Vector2.zero;
        }*/
        //rgd.AddForce(horiz);
      
        /*if (Input.GetButtonDown("Jump"))
            {
            minimum_jump();
        }*/
        
        /*if (Input.GetButtonDown("Jump"))
        {
            if (jump_check)
            {
                jump_timer = 0;
                minimum_jump_check = false;
                jump_check = false;
            }

            jump();
        }
        if (Input.GetButtonDown("Jump")&&jump_timer!=0)
        {
            jump_timer = 0;
        }*/


        /*if (rgd.velocity.y == 0isjumping )
        {
            jump_timer = 0;
            isjumping = false;
        }*/
    }
    /*void minimum_jump()
    {
        Debug.Log("Jump!");
        rgd.AddForce(minimum_jump_vec3, ForceMode2D.Impulse);
    }*/
    void minimum_jump()
    {
        jump_count--;
        //rgd.velocity = new Vector2(rgd.velocity.x, minimum_jump_vec3.y);
        rgd.AddForce(new Vector2(rgd.velocity.x, Player_status.p_status.get_jump_force()), ForceMode2D.Impulse);
    }
    void death()
    {
        Debug.Log("죽음!");
        death_check = true;
    }
    void player_hitted(int dmg)
    {
        Debug.Log("데미지 처리!");
        Player_status.p_status.damage_hp(dmg);
        if(!untouchable_state)
            untouchable_state = true;
    }
    void untouchable()
    {
        if (untouchable_timer >= Player_status.p_status.get_untouchable_time())
        {
            Debug.Log("무적해제!");
            untouchable_state = false;
            untouchable_timer = 0;
        }
        untouchable_timer += Time.deltaTime;
    }
    void player_hiited_force(Vector3 col_pos)
    {
        Vector3 col_direct = transform.position - col_pos;
        int hit_direct;
        if (col_direct.x > 0)
        {
            hit_direct = -1;
        }
        else
        {
            hit_direct = 1;
        }
        rgd.velocity = Vector2.zero;
        can_move = false;
        //rgd.gravityScale = 1;
        rgd.AddForce(new Vector2(hitted_force.x*hit_direct,hitted_force.y),ForceMode2D.Impulse);
        on_hitted = true;
        hitted_timer = hitted_time;
    }
    void hitted_end()
    {
        rgd.velocity = Vector2.zero;
        can_move = true;
        //rgd.gravityScale = 1;
        on_hitted = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!untouchable_state)
            {
                //if (collision.gameObject.transform.parent.GetComponent<Unit>().e_active)
                //{
                    col_pos = collision.transform.position;
                    //player_hiited_force(col_pos);
                    player_hitted(collision.gameObject.GetComponentInParent<GameCharacter>().Attack_point);
                    Debug.Log("피격됨");
                //}
            }
        }
    }
    void OnCollisionStay2D(Collision2D other) // trigger? collision?
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (other.gameObject.layer == 11)
            {
                on_platform = true;
            }

        }

        
    }
    void OnCollisionEnter2D(Collision2D other) // trigger? collision?
    {
        if (other.gameObject.CompareTag("Platform"))//플랫폼에 닿으면 점프횟수 회복?
        {
            if (other.gameObject.layer != 11)
            {
                if (!onground)
                {
                    //Debug.Log("점프회복");
                    jump_count = Player_status.p_status.get_jump_count();
                    dash_recover_check = true;
                    onground = true;
                }
            }
            else
            {

                if (!onground)
                {
                    if (rgd.velocity.y == 0)
                    {
                        // Debug.Log("점프회복");
                        jump_count = Player_status.p_status.get_jump_count();
                        dash_recover_check = true;
                        onground = true;
                    }
                }
                
                  
               
            }
            if (this.GetComponent<player_room_boost_mode>().on_boost)
            {
                this.GetComponent<player_room_boost_mode>().un_boost();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (collision.gameObject.layer == 11)
            {
                on_platform = false;
            }
        }
    }
}



/* 최소 점프 높이
 * getbutton
 * timer 누르는 동안 점프높이=점프높이+%%%
*/