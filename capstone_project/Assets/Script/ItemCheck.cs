using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerStay2D(Collider2D Item)
    {
        if (Item.gameObject.CompareTag("Item"))      //아이템 체크
        {
            Debug.Log("아이템 체크");
            Debug.Log("스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
            Debug.Log("333 스킬여부1 " + Skill.Skill_Slot[0].skill_check + "스킬여부2 " + Skill.Skill_Slot[1].skill_check);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Item.GetComponent<Item>().ItemType == 1)        //액티브
                {
                    if (Skill.Skill_Slot[0].skill_check == false && Skill.Skill_Slot[1].skill_check == false)   //스킬 들어갈 곳이 있는지 확인하는 if문
                    {
                        Debug.Log("아이템획득");
                        Skill.Skill_Slot[0].GetSkillItem(Item.GetComponent<Item>());
                        Debug.Log("222 스킬1 " + Skill.Skill_Slot[0].skill_name + "스킬2 " + Skill.Skill_Slot[1].skill_name);
                        Skill.Skill_Slot[0].skill_check = true;
                        Destroy(Item.gameObject);
                    }
                    else if (Skill.Skill_Slot[0].skill_check == true && Skill.Skill_Slot[1].skill_check == false)
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
                else if (Item.GetComponent<Item>().ItemType == 2)        //패시브
                {
                    //패시브 아이템 클래스에서 함수를 불러와 추가 효과 적용시킬 예정
                    Destroy(Item.gameObject);
                }
            }
        }

        if (Item.gameObject.CompareTag("TreasureBox"))      //아이템 체크
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject Item_D = Instantiate(prefab, new Vector3(Item.transform.position.x, Item.transform.position.y, Item.transform.position.z), Quaternion.identity);
                int Ran = Random.Range(1, 6);
                if (1 <= Ran && 3 >= Ran)
                {
                    Item_D.GetComponent<Item>().ItemType = 1;
                }
                else if (4 <= Ran && 6 >= Ran)
                {
                    Item_D.GetComponent<Item>().ItemType = 2;
                }
                Destroy(Item.gameObject);
            }
        }
    }

}
