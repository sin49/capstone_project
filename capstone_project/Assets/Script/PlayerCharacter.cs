using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : GameCharacter
{
    public Rigidbody2D rgd;
    float jump_timer_limit=0.1f;
    public float jump_timer;
    public int jump_count=1;
    int max_jump_count=1;
    public Vector2 horiz;
    public Vector2 jump_vec;
    public bool onground;//땅에 닿았는지
    public Vector3 move_vector;
    public bool minimum_jump_check;
    public bool jump_check;
    public Vector2 minimum_jump_vec3;
    public float minimum_jump_height;
    public float jump_height;
    public Vector2 jump_start_pos;
    public Vector2 jump_height_pos;
    Attack p_atk;
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
            //if(rgd.velocity.y

            if (Input.GetButton("Jump"))
            {

                jump();
            }
            if (untouchable_state)
                untouchable();
            if (Health_point <= 0)
                death();
        }
    }
    void Update()
    {
        if (!death_check)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (jump_check)
                {
                    jump_timer = 0;
                    jump_check = false;
                }

                minimum_jump();
            }
            if (rgd.velocity.y != 0)
            {
                onground = false;
            }
            else
                onground = true;


            if (!onground)
            {
                /*if (transform.position.y >= jump_height_pos.y&& rgd.velocity.y>0)
                {
                    rgd.velocity = new Vector2(rgd.velocity.x,rgd.velocity.y*0.1f);
                }*/

            }
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
        jump_start_pos = transform.position;
        jump_height_pos = new Vector2(0, jump_start_pos.y + jump_height);
        rgd.velocity=new Vector2(rgd.velocity.x,minimum_jump_vec3.y);
        //rgd.AddForce(minimum_jump_vec3, ForceMode2D.Impulse);
        
        /*Debug.Log("Jumping...");
            if (!Input.GetButton("Jump") || jump_timer >= jump_timer_limit)
            {
                Debug.Log("Jump_end");
                jump_count--;
                jump_check = true;
                return;
            }

            rgd.velocity = new Vector2(rgd.velocity.x, 0);
        if (jump_timer > 0.02)
        {
            jump_vec = Vector2.up * jump_force * jump_timer * 10;
        }
        else
        {
            jump_vec = Vector2.up * jump_force * jump_timer ;
        }
            rgd.AddForce(jump_vec, ForceMode2D.Impulse);
            jump_timer += Time.deltaTime;
        //}*/
    }
    void jump()
    {
        if (!Input.GetButton("Jump") || jump_timer >= jump_timer_limit)
        {
            jump_count--;
            jump_check = true;
            return;
        }
        jump_vec = Vector2.up * jump_force*0.25f;
        rgd.AddForce(jump_vec, ForceMode2D.Impulse);
        jump_height_pos = new Vector2(0, jump_height_pos.y + 2 / jump_timer_limit * Time.deltaTime);

        jump_timer += Time.deltaTime;
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
            
            jump_count += max_jump_count;
            if (jump_count > max_jump_count)
                jump_count = max_jump_count;
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