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
        if (other.tag == "Bullet")
        {
            character_lose_health(other.GetComponent<Bullet>().Damge);
            Debug.Log("총알맞음");
            other.GetComponent<Bullet>().DestroyBullet();
        }
    }

    public void HpCheack()
    {
        if (Health_point <= 0)
        {
            GameObject Item = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //아이템떨어트림
            //여기서 itemtype을 랜덤으로 뽑아서 item스크립트에 넘길 예정임
            int Ran = Random.Range(1, 6);
            if (1 <= Ran && 3 >= Ran)
            {
                Item.GetComponent<Item>().ItemType = 1;
            }
            else if (4 <= Ran && 6 >= Ran)
            {
                Item.GetComponent<Item>().ItemType = 2;
            }
            Destroy(this.gameObject);
        }
    }
}

