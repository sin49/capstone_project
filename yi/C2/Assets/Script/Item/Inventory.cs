using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static public List<Item> Item_InvenData = new List<Item>();    //�κ�
    static public List<Item> Use_InvenData = new List<Item>();     //���� ����

    public List<Slot> InvenSlot;           //�����ڸ�
    public List<Slot> UseInveSlot;         //�����ڸ�

    public int Item_InvenDataCount = 16;     //�κ��丮 ���� ����
    public int Use_InvenDataCount;      //���ǰ� �ִ� ���� ����


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


    public void Refresh()       //���� ������ ���Կ� ����ֱ�
    {
        
        for(int i=0;i< InvenSlot.Count;i++)     //���԰˻�
        {
            if(!InvenSlot[i].FullCheck)
            {
                InvenSlot[i].item = Item_InvenData[Item_InvenData.Count - 1];   //������ ã�� �ִ´� (���� �������� ���� ������)
                InvenSlot[i].ClassCheck();
                break;
            }
        }
    }


    public void CheckList()
    {
        Debug.Log("�κ� ������");
        for (int i = 0; i < Item_InvenData.Count; i++)    
        {
           
            Debug.Log("������ ������ ��ȣ: "+i+"����: " + Item_InvenData[i].SlotNumber + "�̸�" + Item_InvenData[i].Foreignkey + "�̹���"+Item_InvenData[i].Sprite);
        }
        Debug.Log("������� ������");
        for (int i = 0; i < Use_InvenData.Count; i++)
        {
            
            Debug.Log("������ ������ ��ȣ: " + i + "����: " + Use_InvenData[i].SlotNumber + "�̸�" + Use_InvenData[i].Foreignkey + "�̹���" + Use_InvenData[i].Sprite);
        }
    }

    
}
