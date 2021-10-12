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


    public Vector2 hitted_force;

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


    Attack p_atk;

    public Vector2 jump_start_pos;
    public Vector2 jump_height_pos;

    void Start()
    {
        rgd = gameObject.GetComponent<Rigidbody2D>();
        p_atk = gameObject.GetComponent<Attack>();
        max_jump_count = 1;
        jump_count = max_jump_count;
        direction = 1;
        jump_height = minimum_jump_height;
    }
    void FixedUpdate()
    {
        if (!death_check)
        {
            character_move();
            if (transform.rotation.y > 360)
                transform.Rotate(0, -360, 0);
            //if(rgd.velocity.y

            character_move();
            //if(rgd.velocity.y
            if (Input.GetButton("Jump"))
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
                hangTimer -= Time.deltaTime;
            }
            else
            {
                hangTimer = hangtime;
            }
        }
    }
    void dash_recover()
    {
        if (dash_count != max_dash_count)
        {
            dash_recover_timer += Time.deltaTime;
            if (dash_recover_timer >= dash_recover_timer_check && dash_recover_check)
            {
                dash_count = max_dash_count;
            }


        }
    }
    void dash()
    {
        if (Input.GetButtonDown("dash") && dash_count != 0 && can_dash)
        {
            Vector2 dash_direction = p_atk.direction / Mathf.Sqrt(Mathf.Pow(p_atk.direction.x, 2) + Mathf.Pow(p_atk.direction.y, 2));
            rgd.AddForce(dash_direction * dash_force * Time.deltaTime, ForceMode2D.Impulse);
            dash_count--;
            can_dash = false;
            dash_recover_check = false;
        }

    }
    new void character_move()
    {
        //이동속도를 건들 때 move_speed와 velocity.x의 제한값을 건들자

        if (Input.GetButton("Right"))
        {
            if (direction == -1)
            {
                direction_change();
            }
            move_vector = new Vector3(direction * move_speed * Time.deltaTime, 0, 0);
            transform.Translate(move_vector);
        }
        if (Input.GetButton("Left"))
        {
            if (direction == 1)
            {
                direction_change();
            }
            move_vector = new Vector3(direction * move_speed * Time.deltaTime * -1, 0, 0);
            transform.Translate(move_vector);
        }

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
        rgd.velocity = new Vector2(rgd.velocity.x, minimum_jump_vec3.y);

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
    void OnCollisionStay2D(Collision2D other) // trigger? collision?
    {
        if (other.gameObject.CompareTag("Platform"))//플랫폼에 닿으면 점프횟수 회복?
        {

            jump_count = max_jump_count;
            dash_recover_check = true;
            onground = true;
        }
        else if (other.gameObject.CompareTag("Enemy"))//플랫폼에 닿으면 점프횟수 회복?
        {

            player_hitted(other.gameObject.GetComponent<GameCharacter>().Attack_point);
            Debug.Log("피격됨");
        }
    }
    void OnCollisionEnter2D(Collision2D other) // trigger? collision?
    {
        
    }
}



/* 최소 점프 높이
 * getbutton
 * timer 누르는 동안 점프높이=점프높이+%%%
*/