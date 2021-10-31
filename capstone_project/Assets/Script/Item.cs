using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemType;     //������ Ÿ��
    public int Foreignkey;

    // Start is called before the first frame update
    void Start()
    {  
        //Ÿ�Կ� ���� �������� ������ ������ �޸��� ������
        List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
        Foreignkey = Random.Range(0,Data.Count);
        Debug.Log("�� ����: " + Data.Count + "���� ��: " + Foreignkey);
        ItemType = Data[Foreignkey]["ItemType"].ToString();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;
    }

    public void ChangeItem()
    {

    }
}
