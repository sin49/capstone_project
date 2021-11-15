using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Item item;
    public bool FullCheck=false;      //자리가 있는지 체크
    public bool UseSlot=false;      //파츠슬롯인지 체크

    //파츠슬롯은 100부터 시작
    [SerializeField] int SlotNumber;



    public void ChoseItem(Item i)
    {
        item=i;
    }

    public void ChangeItem()
    {
        //들어온 아이템을 자기슬롯번호를 넣는다.
        
        Debug.Log("??뭐야asdad2");
        if (item == null)  //만약 빈공간이면
        {
            Debug.Log("??뭐야2");
            FullCheck = false;   //사용가능 체크
        }
        else
        {
            item.SlotNumber = SlotNumber;
            Debug.Log("??뭐야333333");
            FullCheck = true;
        }
    }

    // 클래스 체크후 슬롯체크, 이미지, 슬롯번호 넣기
    public void ClassCheck()
    {
        Item item = this.gameObject.GetComponent<Slot>().item;

        if (item==null)         //아이템이 없으면
        {
            FullCheck = false;
        }
        else                    //있으면
        {
            FullCheck = true;
            this.gameObject.GetComponent<Image>().sprite = item.Sprite;
            item.SlotNumber = SlotNumber;
        }
    }

    public void UseAndItemChange()
    {
        
        if (item.SlotNumber >= 100) //만약 자신이 장착 슬롯에 있다.
        {
            Debug.Log("장착" + item.Sprite.name);
            Inventory.Use_InvenData.Add(item);      //장착
            ItemEffect0.item0to10.effect(item.Foreignkey);
            Inventory.Item_InvenData.Remove(item);  //인벤슬롯해제
        }
        else
        {
            Debug.Log("인벤" + item.Sprite.name);
            Inventory.Item_InvenData.Add(item);     //인벤슬롯넣기
            ItemEffect0.item0to10.un_effect(item.Foreignkey);
            Inventory.Use_InvenData.Remove(item);   //장착해제
        }
    }
}
