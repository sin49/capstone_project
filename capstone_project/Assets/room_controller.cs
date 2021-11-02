using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_controller : MonoBehaviour
{
    public int room_create_number;//���������
    public GameObject[] room_database;//��
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
    
    public GameObject make_room_V2()//�ƹ� ���̳� �����
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
    public GameObject make_room_V2(GameObject r)//�ƹ� ���� ������ �̾���δ�
    {
        room room_ = r.GetComponent<room>();
        room_.random_door();
        List<door> open_door=new List<door>();
        
        for(int i=0;i< room_.door.Length; i++)
        {
            if(room_.door[i].door_active&& room_.door[i].link == null){
                open_door.Add(room_.door[i]);
            }
        }//���� ���� üũ�ؼ� ���̸鼭 ������� ���� ���� ����Ʈ�� ��´�
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
                                Debug.Log("���� ���ļ� �ı���");
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
                                Debug.Log("���� ���ļ� �ı���");
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
                                Debug.Log("���� ���ļ� �ı���");
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
                                Debug.Log("���� ���ļ� �ı���");
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
        //����Ʈ�� ���� ��ŭ ���� ����� ���� �����Ų��

        //������ ���� �� ���� üũ�Ҽ� �ְ� ���ͷ� ������
        //start�� awake���� �����ٴ� ���� �̿��ؼ� ������ �ٵ� �Ŀ� �ٽ� ���� ����� ������� ����Ѵ� ����?
        //start awake���� ��� ����� list�� ��� ���� ���������� �ҷ����� ������� �ٲٸ� �����ϴ�! �̰� ����
        return null;
        
    }
    public GameObject create_room_V2()//�� �ϳ� ���� �� �̾���̴� ���
    {
        //room[room_count] = make_room_V2();//�� �����
        GameObject b = make_room_V2();//�� �����

        
        if (room.Count == room_create_number)//������� ����
            return null;//��ȯ���� �ʿ��ϸ� ä���
        else
            return create_room_V2(room);//�ƴϸ� �ƾ���̱�


    }
    public GameObject create_room_V2(List<GameObject> room)//������ ��� ����
    {

            if (room.Count != room_create_number)//��ΰ� �շ�������
            {
            if (r_count >= room.Count)
            {
                r_count = 0;
            }
            GameObject r2 = make_room_V2(room[r_count]);//�� ������ �̾���̱�
            r_count++;
            //room[room_count] = make_room_V2(r);
            
                if (room.Count == room_create_number)//������ ����
                    return null;
                else
                    create_room_V2(room);//�׸��� �׹��� ��θ� �˻���
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
/*����� �� �ٲ۴�
 * ���� ���->�� �ϳ� ����� ���� ������ ���ϰ� �׷��� ���� �浹üũ�� �˾Ƽ� ����
 * ������ ����� �����̶� ���� ������ �ȵǴ� ��찡 ����,���ڷ� �̾����� ������ �ʹ� ����
 *
 * �� ���-> �� ����� �� ���� ��� ���� ���� ����� �� ���� �� ���ο� ���� �����....
 *�� ������ �浹üũ�� �ƴ϶� ������ �� ����
 * ���� ����Ǿ��ִٸ� �������� ���� �ʰ� ������ ���� ��
 * 
 */