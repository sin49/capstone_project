using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProduce : MonoBehaviour
{   
    //�������� �����ϴ� �ڵ� (������ �����鿡 �� �ִ�)

    public Item item= new Item();  //������

    void Start()        //�������� �����ϸ� �������� �������� �����.
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
            Debug.Log("��Ƽ�� ������");
            List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
            item.Foreignkey = Random.Range(0, Data.Count);      //������ ����
            item.Sprite = Resources.Load(Data[item.Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;  //�̹����ֱ�
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }
        else if (item.ItemType == 2)
        {
            Debug.Log("�нú� ������");
            List<Dictionary<string, object>> Data = CSVReader.Read("ItemTree");
            item.Foreignkey = Random.Range(0, Data.Count) + 100;
            item.Sprite = Resources.Load(Data[item.Foreignkey-100]["Image"].ToString(), typeof(Sprite)) as Sprite;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.Sprite;
        }
    }
}
