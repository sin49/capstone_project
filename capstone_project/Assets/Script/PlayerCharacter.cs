using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : GameCharacter
{
    public Rigidbody2D rgd;
    float jump_timer_limit = 0.1f;
    public float jump_timer;
    public int jump_count = 1;
    int max_jump_count = 1;
    public Vector2 horiz;
    public Vector2 jump_vec;
    public bool onground;//땅에 닿았는지

    public bool ongrounded_jump_check;

    

    public Vector3 move_vector;

    [Header("jump")]
    public bool minimum_jump_check;
    public bool jump_check;
    public Vector2 minimum_jump_vec3;
    public float minimum_jump_height;
    public float jump_height;

    public float hangtime = 0.2f;
    public float hangTimer;
    public float jumpbuffertime = 0.5f;
    public float jumpbuffertimer;


    

    [Header("dash input")]
    public float dash_force;
    public int dash_count;
    public int max_dash_count = 1;
    public float after_dash_timer;
    public float after_dash_timer_check = 0.05f;
    public bool dash_recover_check;
    public float dash_recover_timer;
    public float dash_recover_timer_check = 0.1f;
    public bool can_dash = true;
    public Vector2 dash_direction;
    public float dash_time = 1f;
    public float dash_timer = 0;
    public bool can_move;
    public bool on_dash;

    Attack p_atk;

    public Vector2 jump_start_pos;
    public Vector2 jump_height_pos;
    

    [Header("hitted  input")]
    public Vector2 hitted_force;
    public float hitted_time = 1f;
    public float hitted_timer = 0;
    private bool on_hitted;
    public Vector2 col_pos;
    public bool col_on_room_boost;

    void Start()
    {
        rgd = gameObject.GetComponent<Rigidbody2D>();
        p_atk = gameObject.GetComponent<Attack>();
        max_jump_count = 1;
        jump_count = max_jump_count;
        direction = 1;
        jump_height = minimum_jump_height;
        can_move = true;
    }
    void FixedUpdate()
    {
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
            if (jumpbuffertimer > 0 && jump_count == max_jump_count && hangTimer > 0)
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
        if (dash_count != max_dash_count)
        {
            dash_recover_timer += Time.deltaTime;
            if (dash_recover_timer >= dash_recover_timer_check)
            {
                dash_count = max_dash_count;
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
            dash_direction =  Vector2.right*direction * dash_force;
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
                move_vector = new Vector3(direction * move_speed * Time.deltaTime, 0, 0);
                transform.Translate(move_vector);
            }
            else if (Input.GetButton("Left"))
            {
                if (direction == 1)
                {
                    direction_change();
                }
                move_vector = new Vector3(direction * move_speed * Time.deltaTime * -1, 0, 0);
                transform.Translate(move_vector);
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
        rgd.AddForce(new Vector2(rgd.velocity.x, minimum_jump_vec3.y), ForceMode2D.Impulse);
    }
    void death()
    {
        Debug.Log("죽음!");
        death_check = true;
    }
    void player_hitted(int dmg)
    {
        Debug.Log("데미지 처리!");
        character_lose_health(dmg);
        if(!untouchable_state)
            untouchable_state = true;
    }
    void untouchable()
    {
        if (untouchable_timer >= untouchable_time)
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
        if (collision.gameObject.CompareTag("Enemy"))//플랫폼에 닿으면 점프횟수 회복?
        {
            if (!untouchable_state)
            {
                col_pos = collision.transform.position;
                player_hiited_force(col_pos);
                player_hitted(collision.gameObject.GetComponentInParent<GameCharacter>().Attack_point);
                Debug.Log("피격됨");
            }
        }
    }
    void OnCollisionStay2D(Collision2D other) // trigger? collision?
    {
       /* if (other.gameObject.CompareTag("Platform"))//플랫폼에 닿으면 점프횟수 회복?
        {
            if (!onground)
            {
                jump_count = max_jump_count;
            }
            dash_recover_check = true;
            onground = true;
        }*/
        
    }
    void OnCollisionEnter2D(Collision2D other) // trigger? collision?
    {
        if (other.gameObject.CompareTag("Platform"))//플랫폼에 닿으면 점프횟수 회복?
        {
            if (!onground&&(this.transform.position-other.gameObject.transform.position).y>0)
            {
                Debug.Log("점프회복");
                jump_count = max_jump_count;
                dash_recover_check = true;
                onground = true;
            }

        }
    }
}



/* 최소 점프 높이
 * getbutton
 * timer 누르는 동안 점프높이=점프높이+%%%
*/