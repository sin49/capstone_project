using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameCharacter
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpCheack();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Bullet")
        {
            character_lose_health(other.GetComponent<Bullet>().Damge);
            Debug.Log("ÃÑ¾Ë¸ÂÀ½");
            other.GetComponent<Bullet>().DestroyBullet();
        }
    }
    
    public void HpCheack()
    {
        if(Health_point<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
