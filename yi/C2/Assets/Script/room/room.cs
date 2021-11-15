using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public float room_width;
    public float room_height;
    public door[] door;
    public int room_element;
    public bool room_cleared;//방을 가봤는지

    [Header("normal_contents")]
    public List<GameObject> enemy = new List<GameObject>();//적이 확인되면 집어 넣기
    public bool delay_check;
    public float delaytime=1.0f;
    public float delaytimer;
    int count;

    public bool on_player;
    private bool open_check;

   public Vector2 XY;
    public void set_XY(float x, float y)
    {
        XY.x=x;
        XY.y=y;
    }
    public Vector2 get_XY()
    {
        return XY;
    }
    public int get_XY_x()
    {
        return (int)XY.x;
    }
    public int get_XY_y()
    {
        return (int)XY.y;
    }
    void Start()
    {
        delaytimer = delaytime;
        open_check = true;
    }
    private void Awake()
    {
       
    }
    void Update()
    {
        if (on_player)
        {
            
            
            if (room_element == 2)//일반 전투 방
            {
                if (!room_cleared)
                {
                    if (collision_door_to_player_check())
                    {
                        battle_mode();
                        if (open_check)
                            close_door();
                    }
                }
                else
                {
                    if (!open_check)
                        open_door();
                }
                
            }
            else
            {
                room_cleared = true;
                //open_door();
            }
            /*if (!link_check)
            {
                check_door();
            }*/
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

   void battle_mode()
    {
        
       
            if (delay_check)
            {
                //적생성한번만
                if (enemy.Count == 0)
                {
                    room_cleared = true;
                }
            }
            else
            {
                delaytimer -= Time.deltaTime;
                if (delaytimer <= 0)
                    delay_check = true;
            }
        
    }
    
    bool collision_door_to_player_check()
    {
        int count = 0;
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].link != null&&door[i].col_Player)
            {
                count++;
            }
        }
        if (count == 0)
        {
            return true;
        }
        else
            return false;
    }
    public void open_door()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].link != null)
            {
                door[i].open_door();
            }
            
        }
        open_check = true;
    }
    public void close_door()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].link != null)
            {
                door[i].close_door();
            }
        }
        open_check = false;
    }
    public void random_door()
    {
        while (count < 2)// 연결되지 않은 문이 하나라도 생길 때 까지
        {
            for (int i = 0; i < door.Length; i++)
            {
                if (door[i].link == null)
                    count += door[i].make_door_random();
            }
        }
    }
    public void make_wall()
    {
        for(int i = 0; i < door.Length; i++)
        {
            if (door[i].link == null)
            {
                door[i].active_wall();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.Add(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //on_player = true;
            //CameraFollow.center = new Vector2(this.transform.position.x, this.transform.position.y);
        }
        if (collision.CompareTag("Enemy"))
        {
            //enemy.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //on_player = false;
            
        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.Remove(collision.gameObject);
        }
    }
}
