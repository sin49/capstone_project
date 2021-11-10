using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    //아이템 구조

    public int Foreignkey;    //아이템코드
    public int ItemType;     //아이템 타입   1:공격보조, 2:스텟 3: 무기강화
    public int Rurity;      //레어도
    public Sprite Sprite;   //이미지

    public int SlotNumber;  //들어가있는 슬롯 번호(아이템, 파츠 포함)
    public int DataNumber;  //들어가있는 리스트 자리 번호 (아이템, 파츠 포함)
    public void ChangeItem(Item item)
    {
        this.Foreignkey = item.Foreignkey;
        this.ItemType = item.ItemType;
        this.Rurity = item.Rurity;
        this.Sprite = item.Sprite;
        this.SlotNumber = item.SlotNumber;
    }
}
