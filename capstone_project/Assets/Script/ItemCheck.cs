using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    

    private void OnTriggerStay2D(Collider2D Item)
    {
        if(Item.gameObject.CompareTag("Item"))      //아이템 체크
        {
            Debug.Log("아이템 체크");
            Debug.Log("스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
            Debug.Log("333 스킬여부1 " + Skill.Skill_Slot[0].skill_check + "스킬여부2 " + Skill.Skill_Slot[1].skill_check);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Skill.Skill_Slot[0].skill_check == false && Skill.Skill_Slot[1].skill_check == false)   //스킬 들어갈 곳이 있는지 확인하는 if문
                {
                    Debug.Log("아이템획득");
                    Skill.Skill_Slot[0].GetSkillItem(Item.GetComponent<Item>());
                    Debug.Log("222 스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
                    Skill.Skill_Slot[0].skill_check = true;
                    Destroy(Item.gameObject);
                }
                else if(Skill.Skill_Slot[0].skill_check == true && Skill.Skill_Slot[1].skill_check == false)
                {
                    Debug.Log("아이템획득");
                    Skill.Skill_Slot[1].GetSkillItem(Item.GetComponent<Item>());
                    Debug.Log("222 스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
                    Skill.Skill_Slot[1].skill_check = true;
                    Destroy(Item.gameObject);
                }
                else
                {
                    Debug.Log("아이템획득");
                    Skill.Skill_Slot[0].GetSkillItem(Item.GetComponent<Item>());
                    Debug.Log("222 스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
                    Skill.Skill_Slot[0].skill_check = true;
                    Destroy(Item.gameObject);
                }
            }
        }
    }
    
}
