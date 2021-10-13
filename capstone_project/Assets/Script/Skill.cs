using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public skill_class[] s_c = new skill_class[2];
    public bool skill_slot_change;
    void Start()
    {

        s_c[0] = new skill_class("�׽�Ʈ1", 1.0f);
        s_c[1] = new skill_class("�׽�Ʈ2", 5.0f);
        skill_slot_change = true;
    }

    // Update is called once per frame
    private void Update()
    {
        skill_system();
    }
    void skill_system()
    {

        if (skill_slot_change)
        {
            if (Input.GetKeyDown(KeyCode.F) && s_c[1].skill_available)
            {
                Debug.Log("�۵����Դϴ�. F��� ");
                s_c[1].skill_active();
                StartCoroutine(s_c[1].CoolTIme());
            }
            if (Input.GetKeyDown(KeyCode.G) && s_c[0].skill_available)
            {
                Debug.Log("�۵����Դϴ�. G��� ");
                s_c[0].skill_active();
                StartCoroutine(s_c[0].CoolTIme());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) && s_c[0].skill_available)
            {
                Debug.Log("�۵����Դϴ�. F���2 ");
                s_c[0].skill_active();
                StartCoroutine(s_c[0].CoolTIme());
            }
            if (Input.GetKeyDown(KeyCode.G) && s_c[1].skill_available)
            {
                Debug.Log("�۵����Դϴ�. G���2 ");
                s_c[1].skill_active();
                StartCoroutine(s_c[1].CoolTIme());
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("��ġ��ȯ ");
            if (!skill_slot_change)
                skill_slot_change = true;
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

    public skill_class(string c, float t)
    {
        skill_name = c;
        skill_cooltime = t;
        skill_available = true;
    }

    public void skill_active()
    {
        if (skill_available == true)    //�۵�
        {
            Debug.Log("�۵��մϴ� ��ų�۵�");
            //skill_available =false;
            skill_available = false;
        }
    }

    //public void skill_cool()
    //{
    //    skill_timer += Time.deltaTime;
    //    if (skill_timer >= skill_cooltime)
    //    {
    //        skill_available = true;
    //        skill_timer = 0;
    //        Debug.Log(skill_name + "��밡��");
    //    }
    //}

    public IEnumerator CoolTIme()
    {
        var wait = new WaitForSeconds(1f);

        for (float i = skill_cooltime; i >= 0; i--)
        {
            yield return wait;
        }
        Debug.Log(skill_name + "��Ÿ�ӳ�");
        skill_available = true;
        yield return null; //

    }
}