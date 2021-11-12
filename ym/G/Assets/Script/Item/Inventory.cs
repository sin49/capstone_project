using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static public List<Item> Item_Inven= new List<Item>();    //�κ�
    static public List<Item> Use_Inven = new List<Item>();     //���� ����
    
    public List<Slot> InvenSlot;           //�����ڸ�
    public List<Slot> UseInveSlot;         //�����ڸ�
    
    public int Item_InvenCount=16;     //�κ��丮 ���� ����
    public int Use_InvenCount;      //���ǰ� �ִ� ���� ����


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
        for (int i = 0; i < Item_Inven.Count; i++)     //���� ������ �ִ� ������ ǥ��
        {
            InvenSlot[Item_Inven[i].SlotNumber].Gain(Item_Inven[i].Sprite);
            InvenSlot[Item_Inven[i].SlotNumber].ChoseItem(Item_Inven[i]);
            Debug.Log("������ ����: " + i + "������ �� ��" + Item_Inven[i].SlotNumber + "������ �̸�" + Item_Inven[i].Foreignkey +"������ �׸�:"+ Item_Inven[i].Sprite.name);
        }
    }
}
