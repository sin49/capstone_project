using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameCharacter
{
    public GameObject prefab;
    void Start()
    {
        
    }
    void Update()
    {
        HpCheack();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Bullet")
        {
            character_lose_health(other.GetComponent<Bullet>().Damge);
            Debug.Log("�Ѿ˸���");
            other.GetComponent<Bullet>().DestroyBullet();
        }
    }
    
    public void HpCheack()
    {
        if(Health_point<=0)
        {
            Instantiate(prefab,new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity); //�����۶���Ʈ��
            //���⼭ itemtype�� �������� �̾Ƽ� item��ũ��Ʈ�� �ѱ� ������
            Destroy(this.gameObject);
        }
    }
}
