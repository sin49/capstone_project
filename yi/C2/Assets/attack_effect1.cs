using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_effect1 : MonoBehaviour
{
    Vector3 a;
    Rigidbody2D rgd2D;
    public Vector2 dir;
    Vector2 p_pos;
    // Start is called before the first frame update
    void Start()
    {
        rgd2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgd2D.velocity=(dir.normalized * 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12||collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
