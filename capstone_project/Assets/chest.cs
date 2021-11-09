using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    int rarity;
    public GameObject item;
    bool open_check;
    void Start()
    {
        float rarity_random = Random.Range(0.0f, 1.0f);
        Debug.Log(rarity_random);
        if (rarity_random < 0.65f)
        {
            rarity = 1;
        }
        else
        {
            rarity = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (open_check)
        {
            open();
        }
    }
    public void set_open()
    {
        open_check = true;
    }
    void open()
    {
        Debug.Log("���� ���" + rarity);
        GameObject chest_Item = Instantiate(item, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        chest_Item.GetComponent<Item>().set_rarity(this.rarity);
        Destroy(this.gameObject);
    }
}
