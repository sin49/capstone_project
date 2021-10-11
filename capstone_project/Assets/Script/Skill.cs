using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public skill_class[] s_c;
    public bool skill_slot_change;
    void Start()
    {
        s_c[0]=new skill_class("�׽�Ʈ1", 1.0f);
        s_c[1] = new skill_class("�׽�Ʈ2", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void skill_system()
    {
        s_c[0].skill_cool();
        s_c[1].skill_cool();
        if (skill_slot_change)
        {
            if (Input.GetButtonDown("f"))
            {
                s_c[1].skill_active();
            }
            if (Input.GetButtonDown("g"))
            {
                s_c[0].skill_active();
            }
        }
        else
        {
            if (Input.GetButtonDown("f"))
            {
                s_c[0].skill_active();
            }
            if (Input.GetButtonDown("g"))
            {
                s_c[1].skill_active();
            }
        }
        if (Input.GetButtonDown("Tab"))
        {
            if(!skill_slot_change)
                skill_slot_change =true;
            else
                skill_slot_change = false;
        }
    }
}
public class skill_class
{
    public string skill_name;

    public int skill_type;
    public float skill_cooltime;//��Ÿ�ӿ� ���� �̾߱��غ��� �ϴ��� ���� �� ���ʷ� ����
    public float skill_timer;
    public bool skill_available;
    public GameObject skill_effect;//�ӽ�? � �������?
    public skill_class(string c,float t){
        skill_name = c;
        skill_cooltime = t;
        skill_available = true;
        }
    public void skill_active()//��� �����ұ�? find?
    {
        if (skill_available == true)
        {
            Debug.Log(skill_name);
            skill_available =false;
        }
       
    }

    public void skill_cool()
    {
        if (skill_available == false)
        {
            skill_timer += Time.deltaTime;
            if (skill_timer >= skill_cooltime)
            {
                skill_available = true;
                skill_timer = 0;
                Debug.Log(skill_name + "��밡��");
            }
        }
    }
}
