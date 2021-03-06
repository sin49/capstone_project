using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameCharacter
{
    public GameObject prefab;
    public bool e_active;
    public float active_timer;
    public float active_time = 1.5f;
    public GameObject Player;
    Color color;
    void Start()
    {
        color = this.gameObject.GetComponent<SpriteRenderer>().color;
        
    }
    void Update()
    {
        if (Player == null && GameObject.FindGameObjectWithTag("Player"))
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        if (e_active)
        {
            HpCheack();
        }
        else 
            active_enemy();

       /* if (Player != null)
        {
            if (transform.position.x - Player.transform.position.x >= 0)
            {
                if (direction == -1)
                {
                    direction_change();
                    direction = -1;
                }
            }
            else
            {
                if (direction == 1)
                {
                    direction_change();
                    direction = 1;
                }
            }
        }*/

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
                Debug.Log("?Ѿ˸???");
                other.GetComponent<Bullet>().DestroyBullet();
            }
        }
    }
   
    public void HpCheack()
    {
        if (Health_point <= 0)
        {
            // GameObject Item = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); //?????۶???Ʈ??
            //???⼭ itemtype?? ???????? ?̾Ƽ? item??ũ??Ʈ?? ?ѱ? ??????
            //int Ran = Random.Range(1, 6);
            //if (1 <= Ran && 3 >= Ran)
            //{
            //    Item.GetComponent<ItemProduce>().item.ItemType = 1;
            //}
            //else if (4 <= Ran && 6 >= Ran)
            //{
            //    Item.GetComponent<ItemProduce>().ItemType = 2;
            //}
            Destroy(this.gameObject);
         
        }
    }
}

