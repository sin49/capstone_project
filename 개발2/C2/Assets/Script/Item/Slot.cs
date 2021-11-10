using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{   //���������� 100���� ����
    [SerializeField] int SlotNumber;
    public Item item;
    public bool SlotCheck;      //�ڸ��� �ִ��� üũ
    public bool InvenSlot;      //�κ��������� üũ

    private void Start()
    {
        SlotCheck = true;
    }
    public int Gain(Sprite sprite)
    {
        this.gameObject.GetComponent<Image>().sprite = sprite;
        SlotCheck = false;
        return SlotNumber;
    }
    public int ReturnNumber()
    {
        return SlotNumber;
    }
    public void SetNumber(int Set)
    {
        SlotNumber = Set;
    }
    public int FindSwapData (int Number)      //������ã��
    {
        int data=-1;
        if (InvenSlot)
        {
            for (int i = 0; i < Inventory.Item_Inven.Count; i++)
            {
                if(Inventory.Item_Inven[i].SlotNumber==Number)      //�� �ڸ��� ������ ã��
                {
                    data = i;
                }
            }
            return data;
        }
        else 
        {
            return -1;
        }
    }

    public void ChoseItem(Item i)
    {
        item=i;
    }
    public void ChangeItem()
    {
        this.gameObject.GetComponent<DragAndDrop>().itemdata.SlotNumber = this.gameObject.GetComponent<Slot>().SlotNumber;
        Debug.Log("??����1"+ this.gameObject.GetComponent<DragAndDrop>().itemdata.Sprite.name);
        if (this.gameObject.GetComponent<DragAndDrop>().itemdata.Sprite==null)
        {
            Debug.Log("??����2");
            SlotCheck = true;
        }
    }
}
