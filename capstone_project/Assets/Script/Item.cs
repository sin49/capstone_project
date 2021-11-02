using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemType;     //������ Ÿ��   1: ��Ƽ��, 2: �нú�
    public int Foreignkey;

    // Start is called before the first frame update
    void Start()
    {
        //Ÿ�Կ� ���� �������� ������ ������ �޸��� ������
        if (ItemType == 1)
        {
            Debug.Log("��Ƽ�� ������");
            List<Dictionary<string, object>> Data = CSVReader.Read("SkillTree");
            Foreignkey = Random.Range(0, Data.Count);
            Debug.Log("�� ����: " + Data.Count + "���� ��: " + Foreignkey);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey]["Image"].ToString(), typeof(Sprite)) as Sprite;
        }
        else if (ItemType == 2)
        {
            Debug.Log("�нú� ������");
            List<Dictionary<string, object>> Data = CSVReader.Read("ItemTree");
            Foreignkey = Random.Range(0, Data.Count) + 100;
            Debug.Log("�� ����: " + Data.Count + "���� ��: " + Foreignkey);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load(Data[Foreignkey - 100]["Image"].ToString(), typeof(Sprite)) as Sprite;
        }
    }

    public void ChangeItem()
    {

    }
}
