using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Remove : MonoBehaviour
{
    public Item item;
    public void Removeit()
    {

           item = this.gameObject.GetComponent<DragAndDrop>().itemdata;
        if(item.SlotNumber>=100)
        {
            Inventory.Item_Inven.RemoveAt(item.DataNumber);
        }
    }
}
