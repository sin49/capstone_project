using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_room_boost_mode : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    internal Vector2 boost_pos;
    public float boost_force;
    public bool on_boost;
    private int boost_direction;
    Rigidbody2D rgd2D;
    public float booster_cancel_delay;
    public float booster_cancel_delay_max;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = this.gameObject.GetComponent<PlayerCharacter>();
        rgd2D = this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerCharacter.col_on_room_boost)
        {
            booster_ready_mode();
        }
        if (on_boost)
        {
            booster_mode(boost_direction);
        }
    }
    public void un_boost()
    {
        this.gameObject.layer = 6;
        playerCharacter.col_on_room_boost = false;
        playerCharacter.can_dash = true;
        playerCharacter.can_move = true;
        rgd2D.gravityScale = 1;
        on_boost = false;
        
    }
    void booster_ready_mode()
    {
        Debug.Log("부스터 준비 중");
        playerCharacter.can_dash = false;
        playerCharacter.can_move = false;
        rgd2D.gravityScale = 0;
        if (Input.GetButtonDown("Left"))
        {
            transform.position = boost_pos;
            rgd2D.velocity = Vector2.zero;
            on_boost = true;
            booster_cancel_delay = booster_cancel_delay_max;
            boost_direction = 0;
            
        }
        if (Input.GetButtonDown("Right"))
        {
            transform.position = boost_pos;
            rgd2D.velocity = Vector2.zero;
            on_boost = true;
            booster_cancel_delay = booster_cancel_delay_max;
            boost_direction = 1;
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = boost_pos;
            rgd2D.velocity = Vector2.zero;
            on_boost = true;
            booster_cancel_delay = booster_cancel_delay_max;
            boost_direction = 2;
        }
        if (Input.GetButtonDown("Down"))
        {
            transform.position = boost_pos;
            rgd2D.velocity = Vector2.zero;
            on_boost = true;
            booster_cancel_delay = booster_cancel_delay_max;
            boost_direction = 3;
        }
    }
    void booster_mode(int i)
    {
        Debug.Log("부스트");
        
            switch (i)
            {
                case 0:
                    playerCharacter.col_on_room_boost = false;
                    rgd2D.velocity = new Vector2(-boost_force, 0);
                booster_cancel_delay -= Time.deltaTime;
                if (booster_cancel_delay <= 0)
                {
                    if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Down"))
                    {
                        Debug.Log("부스터 해제");
                        un_boost();
                    }
                }
                    break;
                case 1:
                playerCharacter.col_on_room_boost = false;
                rgd2D.velocity = new Vector2(boost_force, 0);
                booster_cancel_delay -= Time.deltaTime;
                if (booster_cancel_delay <= 0)
                {
                    if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Down"))
                    {
                        un_boost();
                        Debug.Log("부스터 해제");
                    }
                }
                break;
                case 2:
                playerCharacter.col_on_room_boost = false;
                rgd2D.velocity = new Vector2(0,boost_force);
                booster_cancel_delay -= Time.deltaTime;
                if (booster_cancel_delay <= 0)
                {
                    if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Down"))
                    {
                        un_boost();
                        Debug.Log("부스터 해제");
                    }
                }
                break;
                case 3:
                playerCharacter.col_on_room_boost = false;
                rgd2D.velocity = new Vector2(0,-boost_force);
                booster_cancel_delay -= Time.deltaTime;
                if (booster_cancel_delay <= 0)
                {
                    if (Input.GetButtonDown("left") || Input.GetButtonDown("right") || Input.GetButtonDown("Jump") || Input.GetButtonDown("down"))
                    {
                        un_boost();
                        Debug.Log("부스터 해제");
                    }
                }
                break;
            }

    }
}
