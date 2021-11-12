using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCheck : MonoBehaviour
{
    public GameObject Inven;

    private void Start()
    {
        Inven = GameObject.Find("InventorySystem");
            
    }
    private void OnTriggerStay2D(Collider2D Item)
    {
        if (Item.gameObject.CompareTag("Item"))      //������ üũ
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.Item_InvenData.Count < Inven.GetComponent<Inventory>().Item_InvenDataCount)  //�κ� �ڸ��� ���� ��
                {
                    Inventory.Item_InvenData.Add(Item.GetComponent<ItemProduce>().item);    //������ �߰�
                    Inven.GetComponent<Inventory>().Refresh();      //�󽽷Կ� ������ �ֱ�
                    Destroy(Item.gameObject);
                }
                else
                {
                    Debug.Log("�� á���ϴ�.");
                }
            }
        }
        if (Item.gameObject.CompareTag("TreasureBox"))      //������ üũ
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Item.GetComponent<chest>().set_open();
            }
        }
    }
}

//if (Item.gameObject.CompareTag("TreasureBox"))      //������ üũ
//{
//    if (Input.GetKeyDown(KeyCode.E))
//    {
//        GameObject Item_D = Instantiate(prefab, new Vector3(Item.transform.position.x, Item.transform.position.y, Item.transform.position.z), Quaternion.identity);
//        int Ran = Random.Range(1, 6);
//        if (1 <= Ran && 3 >= Ran)
//        {
//            Item_D.GetComponent<Item>().ItemType = 1;
//        }
//        else if (4 <= Ran && 6 >= Ran)
//        {
//            Item_D.GetComponent<Item>().ItemType = 2;
//        }
//        Destroy(Item.gameObject);
//    }
//private void OnTriggerStay2D(Collider2D Item)
//{
//    if (Item.gameObject.CompareTag("Item"))      //������ üũ
//    {

//        if (Input.GetKeyDown(KeyCode.E))
//        {

//            Debug.Log("�κ� ����:" + Inventory.Item_InvenData.Count + " �� ���� : " + Inven.GetComponent<Inventory>().Item_InvenDataCount);
//            if (Inventory.Item_InvenData.Count < Inven.GetComponent<Inventory>().Item_InvenDataCount)  //�κ� �ڸ��� ���� ��
//            {
//                for (int i = 0; i < Inven.GetComponent<Inventory>().Item_InvenDataCount; i++)    //�󽽷� ã��
//                {
//                    if (Inven.GetComponent<Inventory>().InvenSlot[i].SlotCheck)      //���� �󽽷��̸�
//                    {
//                        Debug.Log("??");
//                        Item.GetComponent<ItemProduce>().item.SlotNumber = i;
//                        Inventory.Item_InvenData.Add(Item.GetComponent<ItemProduce>().item);    //������ �߰�
//                        break;
//                    }
//                }


//                Inven.GetComponent<Inventory>().Refresh();
//                Destroy(Item.gameObject);
//            }
//            else
//            {
//                Debug.Log("�� á���ϴ�.");
//            }
//        }
//    }
//    if (Item.gameObject.CompareTag("TreasureBox"))      //������ üũ
//    {

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            Item.GetComponent<chest>().set_open();
//        }
//    }
//}