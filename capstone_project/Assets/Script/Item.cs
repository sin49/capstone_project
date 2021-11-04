using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    int rarity;//2
    public int Foreignkey;

    // Start is called before the first frame update
    void Start()
    {
        float rarity_random = Random.Range(0.0f, 1.0f);
        Debug.Log(rarity_random);
        if (rarity_random < 0.65f)
        {
            rarity = 0;
        }
        else
        {
            rarity = 1;
        }
            List<Dictionary<string, object>> Data = CSVReader.Read("ItemDB");
            Foreignkey = Random.Range(0, Data.Count);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;
        Debug.Log("등급:"+rarity+"아이템 코드"+Foreignkey);

    }

   public int get_item()
    {
        return Foreignkey;
    }
    public int get_rarity()
    {
        return rarity;
    }
}
