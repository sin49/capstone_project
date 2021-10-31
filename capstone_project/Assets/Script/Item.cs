using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemType;     //아이템 타입
    public int Foreignkey;

    // Start is called before the first frame update
    void Start()
    {  
        //타입에 따라서 가져오는 아이템 파일을 달리할 예정임
        List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
        Foreignkey = Random.Range(0,Data.Count);
        Debug.Log("총 갯수: " + Data.Count + "랜덤 수: " + Foreignkey);
        ItemType = Data[Foreignkey]["ItemType"].ToString();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;
    }

    public void ChangeItem()
    {

    }
}
