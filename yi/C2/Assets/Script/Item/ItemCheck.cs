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
        if (Item.gameObject.CompareTag("Item"))      //아이템 체크
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.Item_InvenData.Count < Inven.GetComponent<Inventory>().Item_InvenDataCount)  //인벤 자리가 있을 때
                {
                    Inventory.Item_InvenData.Add(Item.GetComponent<ItemProduce>().item);    //아이템 추가
                    Inven.GetComponent<Inventory>().Refresh();      //빈슬롯에 아이템 넣기
                    Destroy(Item.gameObject);
                }
                else
                {
                    Debug.Log("꽉 찼습니다.");
                }
            }
        }
        if (Item.gameObject.CompareTag("TreasureBox"))      //아이템 체크
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                Item.GetComponent<chest>().set_open();
            }
        }
    }
}

//if (Item.gameObject.CompareTag("TreasureBox"))      //아이템 체크
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
//    if (Item.gameObject.CompareTag("Item"))      //아이템 체크
//    {

//        if (Input.GetKeyDown(KeyCode.E))
//        {

//            Debug.Log("인벤 갯수:" + Inventory.Item_InvenData.Count + " 총 갯수 : " + Inven.GetComponent<Inventory>().Item_InvenDataCount);
//            if (Inventory.Item_InvenData.Count < Inven.GetComponent<Inventory>().Item_InvenDataCount)  //인벤 자리가 있을 때
//            {
//                for (int i = 0; i < Inven.GetComponent<Inventory>().Item_InvenDataCount; i++)    //빈슬롯 찾기
//                {
//                    if (Inven.GetComponent<Inventory>().InvenSlot[i].SlotCheck)      //만약 빈슬롯이면
//                    {
//                        Debug.Log("??");
//                        Item.GetComponent<ItemProduce>().item.SlotNumber = i;
//                        Inventory.Item_InvenData.Add(Item.GetComponent<ItemProduce>().item);    //아이템 추가
//                        break;
//                    }
//                }


//                Inven.GetComponent<Inventory>().Refresh();
//                Destroy(Item.gameObject);
//            }
//            else
//            {
//                Debug.Log("꽉 찼습니다.");
//            }
//        }
//    }
//    if (Item.gameObject.CompareTag("TreasureBox"))      //아이템 체크
//    {

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            Item.GetComponent<chest>().set_open();
//        }
//    }
//}