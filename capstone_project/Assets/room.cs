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
    public List<GameObject> enemy = new List<GameObject>();//적이 확인되면 집어 넣기
    public int count;
    
    public bool on_player;
    void Start()
    {
        
    }
    private void Awake()
    {
        //random_door();
    }
    void Update()
    {
        if (on_player)
        {
            
            //link_check_door();
            if (room_element == 2)//일반 전투 방
            {
                battle_mode();
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
        
        if (collision_door_to_player_check())
        {
            
            //적생성한번만
            if (enemy.Count == 0)
            {
                open_door();
                room_cleared=true;
            }
            else
            {
                close_door();
            }
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
    }
    public void random_door()
    {
        while (count < 1)// 연결되지 않은 문이 하나라도 생길 때 까지
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
                Debug.Log("벽생성");
                door[i].active_wall();
            }
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
            on_player = false;
        }
    }
}
