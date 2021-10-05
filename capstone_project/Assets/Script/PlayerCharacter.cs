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
    
    void Start()
    {
        rgd = gameObject.GetComponent<Rigidbody2D>();
        max_jump_count = 1;
        jump_count = max_jump_count;
    }
    void Update()
    {
        character_move();
    }
    new void character_move()
    {
       //이동속도를 건들 때 move_speed와 velocity.x의 제한값을 건들자
        
        if (Input.GetButton("Right"))
        {
            horiz = new Vector2(  Time.deltaTime * move_speed * 1000, 0);
        }else if (Input.GetButtonUp("Right"))
        {
            horiz = Vector2.zero;
            rgd.velocity = new Vector2(rgd.velocity.x * 0.2f, rgd.velocity.y);
        }
        if (Input.GetButton("Left"))
        {
            horiz = new Vector2(Time.deltaTime * move_speed * 1000*-1, 0);
        }
        else if (Input.GetButtonUp("Left"))
        {
            horiz = Vector2.zero;
            rgd.velocity = new Vector2(rgd.velocity.x * 0.2f, rgd.velocity.y);
        }

        if (rgd.velocity.x>5)
            rgd.velocity=new Vector2(5,rgd.velocity.y);
        else if (rgd.velocity.x< - 5)
            rgd.velocity = new Vector2(-5, rgd.velocity.y);

        /*if (Input.GetButtonUp("Horizontal"))
        {
            rgd.velocity = Vector2.zero;
        }*/
        /*if (!Input.GetButton("Horizontal"))
        {
           
            horiz = Vector2.zero;
        }*/
        rgd.AddForce(horiz);
        if (Input.GetButtonDown("Jump") && jump_count != 0)
        {
            jump_timer = 0;
        }
        if (Input.GetButton("Jump")&& jump_count != 0)
        {
            jump();
        }
 

        /*if (rgd.velocity.y == 0isjumping )
        {
            jump_timer = 0;
            isjumping = false;
        }*/
    }
    void jump()
    {
        if (!Input.GetButton("Jump") || jump_timer >= jump_timer_limit)
        {
            
            jump_count--;
            return;
        }
        rgd.velocity = new Vector2(rgd.velocity.x,0);
        jump_vec = Vector2.up * jump_force * jump_timer*5;
        rgd.AddForce(jump_vec, ForceMode2D.Impulse);
        jump_timer += Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D other) // trigger? collision?
    {
        if (other.gameObject.CompareTag("Platform"))//플랫폼에 닿으면 점프횟수 회복?
        {
          
            jump_count += max_jump_count;
            if (jump_count > max_jump_count)
                jump_count = max_jump_count;
        }
    }
}
