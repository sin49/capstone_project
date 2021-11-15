using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item;
    public bool FullCheck=false;      //�ڸ��� �ִ��� üũ
    public bool UseSlot=false;      //������������ üũ

    //���������� 100���� ����
    [SerializeField] int SlotNumber;



    public void ChoseItem(Item i)
    {
        item=i;
    }

    public void ChangeItem()
    {
        //���� �������� �ڱ⽽�Թ�ȣ�� �ִ´�.
        
        Debug.Log("??����asdad2");
        if (item == null)  //���� ������̸�
        {
            Debug.Log("??����2");
            FullCheck = false;   //��밡�� üũ
        }
        else
        {
            item.SlotNumber = SlotNumber;
            Debug.Log("??����333333");
            FullCheck = true;
        }
    }

    // Ŭ���� üũ�� ����üũ, �̹���, ���Թ�ȣ �ֱ�
    public void ClassCheck()
    {
        Item item = this.gameObject.GetComponent<Slot>().item;

        if (item==null)         //�������� ������
        {
            FullCheck = false;
        }
        else                    //������
        {
            FullCheck = true;
            this.gameObject.GetComponent<Image>().sprite = item.Sprite;
            item.SlotNumber = SlotNumber;
        }
    }

    public void UseAndItemChange()
    {
        
        if (item.SlotNumber >= 100) //���� �ڽ��� ���� ���Կ� �ִ�.
        {
            Debug.Log("����" + item.Sprite.name);
            Inventory.Use_InvenData.Add(item);      //����
            ItemEffect0.item0to10.effect(item.Foreignkey);
            Inventory.Item_InvenData.Remove(item);  //�κ���������
        }
        else
        {
            Debug.Log("�κ�" + item.Sprite.name);
            Inventory.Item_InvenData.Add(item);     //�κ����Գֱ�
            ItemEffect0.item0to10.un_effect(item.Foreignkey);
            Inventory.Use_InvenData.Remove(item);   //��������
        }
    }
}
