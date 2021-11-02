using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_controller : MonoBehaviour
{
    public int room_create_number;//방생성갯수
    public GameObject[] room_database;//방
    public List<GameObject> room=new List<GameObject>();
    public List<Vector3> room_pos = new List<Vector3>();
    private int r_count;
    public bool make_wall_check;
    public bool map_making_complete;
    public bool make_map_elemental;
    // Start is called before the first frame update
    void Start()
    {
       
        create_room_V2();
        //make_all_link(room);
    }

    // Update is called once per frame
    void Update()
    {
        if (!map_making_complete)
        {
            if (room.Count == room_create_number && !make_wall_check)
            {
                close_no_link_door(room);
                make_wall_check = true;

            }
            if (make_wall_check)
            {
                make_map_element();
            }
            if (make_wall_check && make_map_elemental)
            {
                map_making_complete = true;
            }
        }
    }
   
   public void make_map_element()
    {

        for (int i = 0; i < room.Count; i++)
        {
            if (i == 0)
            {
                room[i].GetComponent<room>().room_element = 1;
                room[i].GetComponent<room>().on_player = true;
            }
            else
            {
                room[i].GetComponent<room>().room_element = 2;
            }
        }
        map_making_complete = true;
    }
    
    public GameObject make_room_V2()//아무 방이나 만든다
    {
        int random_number = Random.Range(0, room_database.Length);
        GameObject a = Instantiate(room_database[random_number]);
        room.Add(a);
        room_pos.Add(a.transform.position);
        //a.GetComponent<room>().open_check_door();
        //a.gameObject.transform.position = new Vector3(0, 0, 0);
        return a;
    }
    door find_door(door[] a, int b)
    {

        List<door> room_ = new List<door>();
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].direct == b)
            {
                room_.Add(a[i]);
            }
        }
        int random = Random.Range(0, room_.Count);
        return room_[random];
    }
    public GameObject make_room_V2(GameObject r)//아무 방을 생성해 이어붙인다
    {
        room room_ = r.GetComponent<room>();
        room_.random_door();
        List<door> open_door=new List<door>();
        
        for(int i=0;i< room_.door.Length; i++)
        {
            if(room_.door[i].door_active&& room_.door[i].link == null){
                open_door.Add(room_.door[i]);
            }
        }//방의 문을 체크해서 문이면서 연결되지 않은 문을 리스트에 담는다
        for(int i = 0; i < open_door.Count; i++)
        {
            if (room.Count != room_create_number)
            {
                Vector3 pos1 = r.transform.position;
                int random_number = Random.Range(0, room_database.Length);
                GameObject a = Instantiate(room_database[random_number]);
                room.Add(a);
                door b;
                switch (open_door[i].direct)
                {
                    case 0:
                        b = find_door(a.GetComponent<room>().door, 1);
                        a.gameObject.transform.position = new Vector3(pos1.x - r.GetComponent<room>().room_width, pos1.y, pos1.z);
                        for(int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.transform.position == room_pos[p])
                            {
                                room.Remove(a);
                                Debug.Log("방이 겹쳐서 파괴됨");
                                Destroy(a);
                                break;
                            }
                        }
                        room_pos.Add(a.transform.position);
                            b.link = open_door[i].gameObject;
                            open_door[i].link = b.gameObject;
                            break;
                        
                    case 1:
                        b = find_door(a.GetComponent<room>().door, 0);
                        a.gameObject.transform.position = new Vector3(pos1.x + r.GetComponent<room>().room_width, pos1.y, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.transform.position == room_pos[p])
                            {
                                room.Remove(a);
                                Debug.Log("방이 겹쳐서 파괴됨");
                                Destroy(a);
                                break;
                            }
                        }
                        room_pos.Add(a.transform.position);
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;

                    case 2:
                        b = find_door(a.GetComponent<room>().door, 3);
                        a.gameObject.transform.position = new Vector3(pos1.x, pos1.y + r.GetComponent<room>().room_height, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.transform.position == room_pos[p])
                            {
                                room.Remove(a);
                                Debug.Log("방이 겹쳐서 파괴됨");
                                Destroy(a);
                                break;
                            }
                        }
                        room_pos.Add(a.transform.position);
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;

                    case 3:
                        b = find_door(a.GetComponent<room>().door, 2);
                        a.gameObject.transform.position = new Vector3(pos1.x, pos1.y - r.GetComponent<room>().room_height, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.transform.position == room_pos[p])
                            {
                                room.Remove(a);
                                Debug.Log("방이 겹쳐서 파괴됨");
                                Destroy(a);
                                break;
                            }
                        }
                        room_pos.Add(a.transform.position);
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;
                    default:
                        Debug.Log("fatal error!");
                        break;
                }
            }
        }
        //리스트의 길이 만큼 방을 만들고 문을 연결시킨다

        //생성된 방은 또 문을 체크할수 있게 제귀로 빠진다
        //start가 awake보다 느리다는 점을 이용해서 생성이 다된 후에 다시 방을 만드는 방식으로 재귀한다 가능?
        //start awake보다 재귀 방식을 list에 담긴 방을 순차적으로 불려오는 방식으로 바꾸면 가능하다! 이건 가능
        return null;
        
    }
    public GameObject create_room_V2()//방 하나 생성 후 이어붙이는 방식
    {
        //room[room_count] = make_room_V2();//방 만들고
        GameObject b = make_room_V2();//방 만들고

        
        if (room.Count == room_create_number)//방다차면 스톱
            return null;//반환값이 필요하면 채우기
        else
            return create_room_V2(room);//아니면 아어붙이기


    }
    public GameObject create_room_V2(List<GameObject> room)//지금은 사용 금지
    {

            if (room.Count != room_create_number)//통로가 뚫려있으면
            {
            if (r_count >= room.Count)
            {
                r_count = 0;
            }
            GameObject r2 = make_room_V2(room[r_count]);//방 생성후 이어붙이기
            r_count++;
            //room[room_count] = make_room_V2(r);
            
                if (room.Count == room_create_number)//다차면 스톱
                    return null;
                else
                    create_room_V2(room);//그리고 그방의 통로를 검사함
            }
        return null;
       
    }
    void close_no_link_door(List<GameObject> d)
    {
        Debug.Log(d.Count);
        for(int i = 0; i < d.Count; i++)
        {
            d[i].GetComponent<room>().make_wall();
        }
    }
}
/*방식을 또 바꾼다
 * 이전 방식->방 하나 만들고 랜덤 돌려서 정하고 그러다 보면 충돌체크로 알아서 연결
 * 문제점 만들고 랜덤이라서 서로 연결이 안되는 경우가 생김,일자로 이어지는 느낌이 너무 강함
 *
 * 새 방식-> 방 만들고 그 방의 모든 문에 방을 만들고 그 방이 또 새로운 방을 만들고....
 *방 연결은 충돌체크가 아니라 생성할 때 연결
 * 문은 연결되어있다면 랜덤으로 가지 않고 무조건 열린 문
 * 
 */