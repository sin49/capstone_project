using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{   //파츠슬롯은 100부터 시작
    [SerializeField] int SlotNumber;
    public Item item;
    public bool SlotCheck;      //자리가 있는지 체크
    public bool InvenSlot;      //인벤슬롯인지 체크

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
    public int FindSwapData (int Number)      //데이터찾기
    {
        int data=-1;
        if (InvenSlot)
        {
            for (int i = 0; i < Inventory.Item_Inven.Count; i++)
            {
                if(Inventory.Item_Inven[i].SlotNumber==Number)      //그 자리의 아이템 찾기
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
        Debug.Log("??뭐야1"+ this.gameObject.GetComponent<DragAndDrop>().itemdata.Sprite.name);
        if (this.gameObject.GetComponent<DragAndDrop>().itemdata.Sprite==null)
        {
            Debug.Log("??뭐야2");
            SlotCheck = true;
        }
    }
}
