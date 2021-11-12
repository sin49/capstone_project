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
                Debug.Log("인식은 합니다요 ");
                Debug.Log("인벤 갯수:" + Inventory.Item_Inven.Count + " 총 갯수 : " + Inven.GetComponent<Inventory>().Item_InvenCount);
                if (Inventory.Item_Inven.Count < Inven.GetComponent<Inventory>().Item_InvenCount)  //인벤 자리가 있을 때
                {
                    for (int i = 0; i < Inven.GetComponent<Inventory>().Item_InvenCount; i++)    //빈슬롯 찾기
                    {
                        if (Inven.GetComponent<Inventory>().InvenSlot[i].SlotCheck)      //만약 빈슬롯이면
                        {
                            Debug.Log("??");
                            Item.GetComponent<ItemProduce>().item.SlotNumber = i;
                            Inventory.Item_Inven.Add(Item.GetComponent<ItemProduce>().item);    //아이템 추가
                            Item.GetComponent<ItemProduce>().item.DataNumber = Inventory.Item_Inven.Count - 1;
                            break;
                        }
                    }


                    Inven.GetComponent<Inventory>().Refresh();
                    Destroy(Item.gameObject);
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
 