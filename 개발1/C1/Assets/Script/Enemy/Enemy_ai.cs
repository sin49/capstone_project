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
    bool weight_dir;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void move_ai(int i)//�̵� ���
    {
        switch (i)
        {
            case 0:
                break;
            case 1://�÷��̾� �߰�(�������� ����)
                dir = this.transform.position - Player.transform.position;
                this.transform.Translate(dir * 2 * Time.deltaTime);
                break;
            case 2://�÷��̾� �߰�(�������� ����o)
                dir = this.transform.position - Player.transform.position;
                
                if (this.transform.position.x > Player.transform.position.x + 4)
                {
                    weight_dir = true;
                }
                else if (this.transform.position.x < Player.transform.position.x - 4)
                {
                    weight_dir = false;
                }

                if (weight_dir)
                {
                    transform.Translate(2 * Vector3.left * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.right * 2 * Time.deltaTime);
                }
                if (this.transform.position.y < Player.transform.position.y)//����ĳ��Ʈ ���� ���� ������� �÷��������� ����
                {

                }
                else if (this.transform.position.y > Player.transform.position.y)//����ĳ��Ʈ �Ʒ��� ���� ������� �÷����� ������ ��������
                {

                }
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
            case 2://���� ������Ʈ ����
                dir = create_position[0].position - Gamemanager.GM.get_player_transform().position;
                float dir_= Mathf.Log(Mathf.Pow(dir.x, 2) + Mathf.Pow(dir.y, 2));
                if (dir_ < 2)
                {
                   rotation = Quaternion.LookRotation(dir.normalized);
                    GameObject atk=Instantiate(create_object[0], create_position[0].position,rotation);
                }
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
