using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    //������ ����

    public int Foreignkey;    //�������ڵ�
    public int ItemType;     //������ Ÿ��   1:���ݺ���, 2:���� 3: ���Ⱝȭ
    public int Rurity;      //���
    public Sprite Sprite;   //�̹���

    public int SlotNumber;  //���ִ� ���� ��ȣ(������, ���� ����)
   // public int DataNumber;  //���ִ� ����Ʈ �ڸ� ��ȣ (������, ���� ����)
    public void ChangeItem(Item item)
    {
        this.Foreignkey = item.Foreignkey;
        this.ItemType = item.ItemType;
        this.Rurity = item.Rurity;
        this.Sprite = item.Sprite;
        this.SlotNumber = item.SlotNumber;
    }
}
