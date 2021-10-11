using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int Hp;
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
            Hp -= other.GetComponent<Bullet>().Damge;
            Debug.Log("ÃÑ¾Ë¸ÂÀ½");
            other.GetComponent<Bullet>().DestroyBullet();
        }
    }
    
    public void HpCheack()
    {
        if(Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
