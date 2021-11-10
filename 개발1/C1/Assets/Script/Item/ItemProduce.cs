using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProduce : MonoBehaviour
{   
    //아이템을 생성하는 코드 (아이템 프리펩에 들어가 있다)

    public Item item= new Item();  //아이템

    void Start()        //아이템이 등장하면 랜덤으로 아이템을 만든다.
    {
        ItemCreate();
    }

    public void ItemType()
    {
        int Ran = Random.Range(1, 6);
        if (1 <= Ran && 3 >= Ran)
        {
            item.ItemType = 1;
        }
        else if (4 <= Ran && 6 >= Ran)
        {
            item.ItemType = 2;
        }
    }

    public void ItemCreate()
    {
        if (item.ItemType == 1)
        {
            Debug.Log("액티브 아이템");
            List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
            item.Foreignkey = Random.Range(0, Data.Count);      //아이템 배정
            item.Sprite = Resources.Load(Data[item.Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;  //이미지주기
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }
        else if (item.ItemType == 2)
        {
            Debug.Log("패시브 아이템");
            List<Dictionary<string, object>> Data = CSVReader.Read("ItemTree");
            item.Foreignkey = Random.Range(0, Data.Count) + 100;
            item.Sprite = Resources.Load(Data[item.Foreignkey-100]["Image"].ToString(), typeof(Sprite)) as Sprite;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }
    }
}
