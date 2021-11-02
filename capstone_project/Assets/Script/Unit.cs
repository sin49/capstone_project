using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameCharacter
{
    public GameObject prefab;
    public bool e_active;
    public float active_timer;
    public float active_time = 1.5f;
    Color color;
    void Start()
    {
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
    }
    void Update()
    {
        if (e_active)
            HpCheack();
        else
            active_enemy();

    }
    void active_enemy()
    {
        if (active_timer < active_time)
        {
            color.a = active_timer;
            this.gameObject.GetComponent<SpriteRenderer>().color = color;
            active_timer += Time.deltaTime;
        }
        else
        {
            color.a = 1;
            this.gameObject.GetComponent<SpriteRenderer>().color = color;
            e_active = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (e_active)
        {
            if (other.tag == "Bullet")
            {
                character_lose_health(other.GetComponent<Bullet>().Damge);
                Debug.Log("총알맞음");
                other.GetComponent<Bullet>().DestroyBullet();
            }
        }
    }

    public void HpCheack()
    {
        if (Health_point <= 0)
        {
           // GameObject Item = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //아이템떨어트림
            //여기서 itemtype을 랜덤으로 뽑아서 item스크립트에 넘길 예정임
            /*int Ran = Random.Range(1, 6);
            if (1 <= Ran && 3 >= Ran)
            {
                Item.GetComponent<Item>().ItemType = 1;
            }
            else if (4 <= Ran && 6 >= Ran)
            {
                Item.GetComponent<Item>().ItemType = 2;
            }*/
            Destroy(this.gameObject);
        }
    }
}

