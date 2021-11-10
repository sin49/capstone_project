using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static public List<Item> Item_Inven= new List<Item>();    //인벤
    static public List<Item> Use_Inven = new List<Item>();     //파츠 장착
    
    public List<Slot> InvenSlot;           //슬롯자리
    public List<Slot> UseInveSlot;         //슬롯자리
    
    public int Item_InvenCount=16;     //인벤토리 슬롯 갯수
    public int Use_InvenCount;      //사용되고 있는 슬롯 갯수


    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start()
    {
        Refresh();
    }


    public void Refresh()
    {
        for (int i = 0; i < Item_Inven.Count; i++)     //현재 가지고 있는 아이템 표시
        {
            InvenSlot[Item_Inven[i].SlotNumber].Gain(Item_Inven[i].Sprite);
            InvenSlot[Item_Inven[i].SlotNumber].ChoseItem(Item_Inven[i]);
            Debug.Log("아이템 슬롯: " + i + "아이템 들어간 곳" + Item_Inven[i].SlotNumber + "아이템 이름" + Item_Inven[i].Foreignkey +"아이템 그림:"+ Item_Inven[i].Sprite.name);
        }
    }
}
