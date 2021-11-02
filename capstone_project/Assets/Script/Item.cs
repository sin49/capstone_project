using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemType;     //아이템 타입   1: 액티브, 2: 패시브
    public int Foreignkey;

    // Start is called before the first frame update
    void Start()
    {
        //타입에 따라서 가져오는 아이템 파일을 달리할 예정임
        if (ItemType == 1)
        {
            Debug.Log("액티브 아이템");
            List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
            Foreignkey = Random.Range(0, Data.Count);
            Debug.Log("총 갯수: " + Data.Count + "랜덤 수: " + Foreignkey);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;
        }
        else if (ItemType == 2)
        {
            Debug.Log("패시브 아이템");
            List<Dictionary<string, object>> Data = CSVReader.Read("ItemTree");
            Foreignkey = Random.Range(0, Data.Count) + 100;
            Debug.Log("총 갯수: " + Data.Count + "랜덤 수: " + Foreignkey);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey - 100]["Image"].ToString(), typeof(Sprite)) as Sprite;
        }
    }

    public void ChangeItem()
    {

    }
}
