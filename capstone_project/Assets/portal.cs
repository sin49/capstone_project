using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public door door_;
    public float force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("충돌체크");
            GameObject player = collision.gameObject;
            Rigidbody2D rgd2D;
            //player.SetActive(false);
            switch (door_.direct)
            {
                case 0:
                    door_.link.transform.parent.gameObject.GetComponent<room>().on_player=true;
                    door_.link.transform.parent.gameObject.SetActive(true);
                    player.transform.position = new Vector2(door_.link.GetComponent<door>().portal_exit.position.x, player.transform.position.y);
                   // door_.transform.parent.gameObject.GetComponent<room>().on_player = false;
                    break;
                case 1:
                    door_.link.transform.parent.gameObject.GetComponent<room>().on_player = true;
                    door_.link.transform.parent.gameObject.SetActive(true);
                    player.transform.position =new Vector2 (door_.link.GetComponent<door>().portal_exit.position.x, player.transform.position.y);
                   // door_.transform.parent.gameObject.GetComponent<room>().on_player = false;
                    break;
                //case 1:
                    
                    //break;
                case 2:
                    door_.link.transform.parent.gameObject.GetComponent<room>().on_player = true;
                    door_.link.transform.parent.gameObject.SetActive(true);
                    player.transform.position = new Vector2(player.transform.position.x, door_.link.GetComponent<door>().portal_exit.position.y);

                    rgd2D = player.GetComponent<Rigidbody2D>();
                    rgd2D.velocity=new Vector2(rgd2D.velocity.x, 0);
                    rgd2D.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
                   // door_.transform.parent.gameObject.GetComponent<room>().on_player = false;
                    break;
                case 3:
                    door_.link.transform.parent.gameObject.GetComponent<room>().on_player = true;
                    door_.link.transform.parent.gameObject.SetActive(true);
                    player.transform.position = new Vector2(player.transform.position.x, door_.link.GetComponent<door>().portal_exit.position.y);

                    rgd2D = player.GetComponent<Rigidbody2D>();
                    rgd2D.velocity = new Vector2(rgd2D.velocity.x, 0);
                    rgd2D.AddForce(new Vector2(0, -1*force), ForceMode2D.Impulse);
                   // door_.transform.parent.gameObject.GetComponent<room>().on_player = false;
                    break;
                default:
                    Debug.Log("error");
                    break;
            }
            
            
        }
    }
}
