using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public skill_class[] s_c = new skill_class[2];
    public bool skill_slot_change;
    void Start()
    {

        s_c[0] = new skill_class("테스트1", 1.0f);
        s_c[1] = new skill_class("테스트2", 5.0f);
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
                Debug.Log("작동중입니다. F사용 ");
                s_c[1].skill_active();
                StartCoroutine(s_c[1].CoolTIme());
            }
            if (Input.GetKeyDown(KeyCode.G) && s_c[0].skill_available)
            {
                Debug.Log("작동중입니다. G사용 ");
                s_c[0].skill_active();
                StartCoroutine(s_c[0].CoolTIme());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F) && s_c[0].skill_available)
            {
                Debug.Log("작동중입니다. F사용2 ");
                s_c[0].skill_active();
                StartCoroutine(s_c[0].CoolTIme());
            }
            if (Input.GetKeyDown(KeyCode.G) && s_c[1].skill_available)
            {
                Debug.Log("작동중입니다. G사용2 ");
                s_c[1].skill_active();
                StartCoroutine(s_c[1].CoolTIme());
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("위치변환 ");
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
    public float skill_cooltime;//쿨타임에 대해 이야기해보기 일단은 시전 후 몇초로 제작
    public float skill_timer;
    public bool skill_available;
    public GameObject skill_effect;//임시? 어떤 방식으로?

    public skill_class(string c, float t)
    {
        skill_name = c;
        skill_cooltime = t;
        skill_available = true;
    }

    public void skill_active()
    {
        if (skill_available == true)    //작동
        {
            Debug.Log("작동합니다 스킬작동");
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
    //        Debug.Log(skill_name + "사용가능");
    //    }
    //}

    public IEnumerator CoolTIme()
    {
        var wait = new WaitForSeconds(1f);

        for (float i = skill_cooltime; i >= 0; i--)
        {
            yield return wait;
        }
        Debug.Log(skill_name + "쿨타임끝");
        skill_available = true;
        yield return null; //

    }
}