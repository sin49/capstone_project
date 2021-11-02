using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerStay2D(Collider2D Item)
    {
        if (Item.gameObject.CompareTag("Item"))      //������ üũ
        {
            Debug.Log("������ üũ");
            Debug.Log("��ų1 " + Skill.Skill_Slot[0].skill_name + "��ų2 " + Skill.Skill_Slot[1].skill_name);
            Debug.Log("333 ��ų����1 " + Skill.Skill_Slot[0].skill_check + "��ų����2 " + Skill.Skill_Slot[1].skill_check);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Item.GetComponent<Item>().ItemType == 1)        //��Ƽ��
                {
                    if (Skill.Skill_Slot[0].skill_check == false && Skill.Skill_Slot[1].skill_check == false)   //��ų �� ���� �ִ��� Ȯ���ϴ� if��
                    {
                        Debug.Log("������ȹ��");
                        Skill.Skill_Slot[0].GetSkillItem(Item.GetComponent<Item>());
                        Debug.Log("222 ��ų1 " + Skill.Skill_Slot[0].skill_name + "��ų2 " + Skill.Skill_Slot[1].skill_name);
                        Skill.Skill_Slot[0].skill_check = true;
                        Destroy(Item.gameObject);
                    }
                    else if (Skill.Skill_Slot[0].skill_check == true && Skill.Skill_Slot[1].skill_check == false)
                    {
                        Debug.Log("������ȹ��");
                        Skill.Skill_Slot[1].GetSkillItem(Item.GetComponent<Item>());
                        Debug.Log("222 ��ų1 " + Skill.Skill_Slot[0].skill_name + "��ų2 " + Skill.Skill_Slot[1].skill_name);
                        Skill.Skill_Slot[1].skill_check = true;
                        Destroy(Item.gameObject);
                    }
                    else
                    {
                        Debug.Log("������ȹ��");
                        Skill.Skill_Slot[0].GetSkillItem(Item.GetComponent<Item>());
                        Debug.Log("222 ��ų1 " + Skill.Skill_Slot[0].skill_name + "��ų2 " + Skill.Skill_Slot[1].skill_name);
                        Skill.Skill_Slot[0].skill_check = true;
                        Destroy(Item.gameObject);
                    }
                }
                else if (Item.GetComponent<Item>().ItemType == 2)        //�нú�
                {
                    //�нú� ������ Ŭ�������� �Լ��� �ҷ��� �߰� ȿ�� �����ų ����
                    Destroy(Item.gameObject);
                }
            }
        }

        if (Item.gameObject.CompareTag("TreasureBox"))      //������ üũ
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
