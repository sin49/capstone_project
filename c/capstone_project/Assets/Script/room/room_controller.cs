using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_controller : MonoBehaviour
{
    public int room_create_number;//规积己肮荐
    int a;
    public GameObject[] room_database;//规
    public List<GameObject> room = new List<GameObject>();
    public List<Vector2> room_pos = new List<Vector2>();
    private int r_count;
    public bool make_wall_check;
    public bool map_making_complete;
    public bool make_map_elemental;
    int x = 9;
    int y = 9;
    
    public int[,] mini_map;
    //List<Dictionary<string, object>> m_Data = CSVReader.Read("map_making");
    // Start is called before the first frame update
    void Start()
    {
        mini_map = new int[3, 3];
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
            } else if (i == room.Count - 1)
            {
                room[i].GetComponent<room>().room_element = 4;
            }
            else
            {
                room[i].GetComponent<room>().room_element = 2;
            }
        }
        map_making_complete = true;
    }

    public GameObject make_room_V2()//酒公 规捞唱 父电促
    {
        int random_number = Random.Range(0, room_database.Length);
        GameObject a = Instantiate(room_database[random_number]);
        a.GetComponent<room>().set_XY(x / 2 + 1, y / 2 + 1);
        room.Add(a);
        //mini_map[x /2+1, y /2+1] = 2;
        room_pos.Add(a.GetComponent<room>().get_XY());
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
    
    public GameObject make_room_V2(GameObject r)//酒公 规阑 积己秦 捞绢嘿牢促
    {
        room room_ = r.GetComponent<room>();
        room_.random_door();
        Vector2 r_XY = room_.get_XY();
        bool destroy=false;
        List<door> open_door = new List<door>();
        int room_x = room_.get_XY_x();
        int room_y = room_.get_XY_y();
        for (int i = 0; i < room_.door.Length; i++)
        {
            if (room_.door[i].door_active && room_.door[i].link == null) {
                open_door.Add(room_.door[i]);
                
            }
        }
        
        //规狼 巩阑 眉农秦辑 巩捞搁辑 楷搬登瘤 臼篮 巩阑 府胶飘俊 淬绰促
        for (int i = 0; i < open_door.Count; i++)
        {
            if (room.Count < room_create_number)
            {
                Vector3 pos1 = r.transform.position;
                int random_number = Random.Range(0, room_database.Length);
                GameObject a = Instantiate(room_database[random_number]);
                room a_room = a.GetComponent<room>();
                room.Add(a);
                door b;
                switch (open_door[i].direct)
                {
                    case 0:

                        a_room.set_XY(r_XY[0] - 3, r_XY[1]);
                        b = find_door(a.GetComponent<room>().door, 1);
                        a.gameObject.transform.position = new Vector3(pos1.x - r.GetComponent<room>().room_width, pos1.y, pos1.z);
                        for (int p = 0; p < room.Count; p++)
                        {
                            if (a_room.get_XY() == room[p].GetComponent<room>().get_XY())
                            {
                                room.Remove(a);
                                Debug.Log("规捞 般媚辑 颇鲍凳" + (r_XY[0] -3) + r_XY[1]);
                                Destroy(a);
                                destroy = true;
                                break;
                            }
                        }
                        if (!destroy)
                        {
                            room_pos.Add(new Vector2(r_XY[0] - 3, r_XY[1]));//积己 矫虐绰 规狼 谅钎 啊廉坷扁
                            
                            
                            //mini_map = new int[new_x, y];
                           /* for(int x_ = 0; x_ < x; x_++)
                            {
                                for(int y_ = 0; y_ < y; y_++)
                                {
                                    mini_map[x_, y_] = mini_map[x_ + 3, y_];

                                }
                            }*/
                        }
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;

                    case 1:
                        a.GetComponent<room>().set_XY(r_XY[0] + 3, r_XY[1]);
                        b = find_door(a.GetComponent<room>().door, 0);
                        a.gameObject.transform.position = new Vector3(pos1.x + r.GetComponent<room>().room_width, pos1.y, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.GetComponent<room>().get_XY() == room[p].GetComponent<room>().get_XY())
                            {
                                room.Remove(a);
                                Debug.Log("规捞 般媚辑 颇鲍凳"+(r_XY[0]+3) + r_XY[1]);
                                Destroy(a);
                                destroy = true;
                                break;
                            }
                        }
                        if (!destroy)
                        {
                            room_pos.Add(new Vector2(r_XY[0] + 3, r_XY[1]));
                            
                        }
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;

                    case 2:
                        a.GetComponent<room>().set_XY(r_XY[0], r_XY[1] + 3);
                        b = find_door(a.GetComponent<room>().door, 3);
                        a.gameObject.transform.position = new Vector3(pos1.x, pos1.y + r.GetComponent<room>().room_height, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.GetComponent<room>().get_XY() == room[p].GetComponent<room>().get_XY())
                            {
                                room.Remove(a);
                                Debug.Log("规捞 般媚辑 颇鲍凳" + r_XY[0] + (r_XY[1] + 3));
                                Destroy(a);
                                destroy = true;
                                break;
                            }
                        }
                        if (!destroy)
                        {
                            room_pos.Add(new Vector2(r_XY[0], r_XY[1] + 3));
                            
                        }
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;

                    case 3:
                        a.GetComponent<room>().set_XY(r_XY[0], r_XY[1] - 3);
                        b = find_door(a.GetComponent<room>().door, 2);
                        a.gameObject.transform.position = new Vector3(pos1.x, pos1.y - r.GetComponent<room>().room_height, pos1.z);
                        for (int p = 0; p < room_pos.Count; p++)
                        {
                            if (a.GetComponent<room>().get_XY() == room[p].GetComponent<room>().get_XY())
                            {
                                room.Remove(a);
                                Debug.Log("规捞 般媚辑 颇鲍凳"+ r_XY[0]+ (r_XY[1] - 3));
                                Destroy(a);
                                destroy = true;
                                break;
                            }
                        }
                        if (!destroy)
                        {
                            room_pos.Add(new Vector2(r_XY[0], r_XY[1] - 3));
                            
                        }
                        b.link = open_door[i].gameObject;
                        open_door[i].link = b.gameObject;
                        break;
                    default:
                        Debug.Log("fatal error!");
                        break;
                }
            }
        }
        //府胶飘狼 辨捞 父怒 规阑 父甸绊 巩阑 楷搬矫挪促

        //积己等 规篮 肚 巩阑 眉农且荐 乐霸 力蓖肺 狐柳促
        //start啊 awake焊促 蠢府促绰 痢阑 捞侩秦辑 积己捞 促等 饶俊 促矫 规阑 父靛绰 规侥栏肺 犁蓖茄促 啊瓷?
        //start awake焊促 犁蓖 规侥阑 list俊 淬变 规阑 鉴瞒利栏肺 阂妨坷绰 规侥栏肺 官操搁 啊瓷窍促! 捞扒 啊瓷
        return null;

    }
    public GameObject create_room_V2()//规 窍唱 积己 饶 捞绢嘿捞绰 规侥
    {
        //room[room_count] = make_room_V2();//规 父甸绊
        GameObject b = make_room_V2();//规 父甸绊
        a++;
        if (room.Count< room_create_number)
        {
            return create_room_V2(room);//酒聪搁 酒绢嘿捞扁
            
        }
        else
        {
            return null;//馆券蔼捞 鞘夸窍搁 盲快扁

        }


    }
    public GameObject create_room_V2(List<GameObject> room)//瘤陛篮 荤侩 陛瘤
    {
        if (room.Count < room_create_number)//烹肺啊 墩妨乐栏搁
            {
            if (r_count >= room.Count)
            {
                
                r_count = room.Count-1;
                room[r_count].GetComponent<room>().random_door();
            }
            GameObject r2 = make_room_V2(room[r_count]);//规 积己饶 捞绢嘿捞扁
            r_count++;
            //room[room_count] = make_room_V2(r);
            
                if (room.Count> room_create_number)//促瞒搁 胶砰
                    return null;
                else
                    create_room_V2(room);//弊府绊 弊规狼 烹肺甫 八荤窃
            }
        return null;
       
    }
    void close_no_link_door(List<GameObject> d)
    {
        for(int i = 0; i < d.Count; i++)
        {
            d[i].GetComponent<room>().make_wall();
        }
    }
    void reset_all()
    {
        while (room.Count != 0)
        {
            room.RemoveAt(room.Count - 1);
        }
        while (room_pos.Count != 0)
        {
            room_pos.RemoveAt(room_pos.Count - 1);
        }
    }
}
/*规侥阑 肚 官槽促
 * 捞傈 规侥->规 窍唱 父甸绊 罚待 倒妨辑 沥窍绊 弊矾促 焊搁 面倒眉农肺 舅酒辑 楷搬
 * 巩力痢 父甸绊 罚待捞扼辑 辑肺 楷搬捞 救登绰 版快啊 积辫,老磊肺 捞绢瘤绰 蠢肠捞 呈公 碍窃
 *
 * 货 规侥-> 规 父甸绊 弊 规狼 葛电 巩俊 规阑 父甸绊 弊 规捞 肚 货肺款 规阑 父甸绊....
 *规 楷搬篮 面倒眉农啊 酒聪扼 积己且 锭 楷搬
 * 巩篮 楷搬登绢乐促搁 罚待栏肺 啊瘤 臼绊 公炼扒 凯赴 巩
 * 
 */