using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    //������ ����

    public int Foreignkey;    //�������ڵ�
    public int ItemType;     //������ Ÿ��   1:���ݺ���, 2:���� 3: ���Ⱝȭ
    public int Rarity;      //���
    public Sprite Sprite;   //�̹���

    public int SlotNumber;  //���ִ� ���� ��ȣ(������, ���� ����)
    private bool effecting;
    // public int DataNumber;  //���ִ� ����Ʈ �ڸ� ��ȣ (������, ���� ����)
    public void ChangeItem(Item item)
    {
        this.Foreignkey = item.Foreignkey;
        this.ItemType = item.ItemType;
        this.Rarity = item.Rarity;
        this.Sprite = item.Sprite;
        this.SlotNumber = item.SlotNumber;
    }
    public void set_effecting_on()
    {
        effecting = true;
    }
    public void set_effecting_off()
    {
        effecting = false;
    }
    public bool get_effecting()
    {
        return effecting;
    }
}
