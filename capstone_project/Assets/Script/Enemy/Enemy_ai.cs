using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ai : MonoBehaviour
{
    public List<GameObject> create_object = new List<GameObject>();
    public List<Transform> create_position = new List<Transform>();
    Vector2 dir;
    private Quaternion rotation;
    float attack_timer;
    float attack_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move_ai(int i)//�̵� ���
    {
        switch (i)
        {
            case 0://�������� ����
                break;
            case 1://�÷��̾� �߰�(�������� ����)
                break;
            default:
                break;
        }
    }
    /*public bool move_condition(int i)//�̵��� ������ �ִ°�?
    {
        switch (i)
        {
            case 0://����
                return true;
            case 1:
                return false;
            default:
                return false;
        }

    }*/
    public void attack_ai(int i)//���� ���
    {
        switch (i)
        {
            case 0://�������� ����
                break;
            case 1://0�� ������Ʈ�� 0�� ��ġ���� �÷��̾�� �߻�
                dir= create_position[0].position-Gamemanager.GM.get_player_transform().position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject obj = Instantiate(create_object[0], create_position[0]. position,rotation );
                break;
            default:

                break;
        }
    }
   /* public bool attack_condition(int i)//���ݿ� ������ �ִ°�?
    {
        switch (i)
        {
            case 0://����
                return true;
            case 1:
                return false;
            default:
                return false;
        }

    }*/
}