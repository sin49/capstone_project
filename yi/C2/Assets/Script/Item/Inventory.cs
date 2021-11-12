using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static public List<Item> Item_InvenData = new List<Item>();    //인벤
    static public List<Item> Use_InvenData = new List<Item>();     //파츠 장착

    public List<Slot> InvenSlot;           //슬롯자리
    public List<Slot> UseInveSlot;         //슬롯자리

    public int Item_InvenDataCount = 16;     //인벤토리 슬롯 갯수
    public int Use_InvenDataCount;      //사용되고 있는 슬롯 갯수


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckList();
        }
    }
    private void Start()
    {
        Refresh();
    }


    public void Refresh()       //먹은 아이템 슬롯에 집어넣기
    {
        
        for(int i=0;i< InvenSlot.Count;i++)     //슬롯검사
        {
            if(!InvenSlot[i].FullCheck)
            {
                InvenSlot[i].item = Item_InvenData[Item_InvenData.Count - 1];   //슬롯을 찾아 넣는다 (가장 마지막에 들어온 아이템)
                InvenSlot[i].ClassCheck();
                break;
            }
        }
    }


    public void CheckList()
    {
        Debug.Log("인벤 아이템");
        for (int i = 0; i < Item_InvenData.Count; i++)    
        {
           
            Debug.Log("아이템 데이터 번호: "+i+"슬롯: " + Item_InvenData[i].SlotNumber + "이름" + Item_InvenData[i].Foreignkey + "이미지"+Item_InvenData[i].Sprite);
        }
        Debug.Log("사용중인 아이템");
        for (int i = 0; i < Use_InvenData.Count; i++)
        {
            
            Debug.Log("아이템 데이터 번호: " + i + "슬롯: " + Use_InvenData[i].SlotNumber + "이름" + Use_InvenData[i].Foreignkey + "이미지" + Use_InvenData[i].Sprite);
        }
    }

    
}
