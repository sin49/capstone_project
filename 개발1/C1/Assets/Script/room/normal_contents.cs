using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_contents : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.transform.parent.gameObject.GetComponent<room>().room_cleared)
        {
            chest.SetActive(true);
            Destroy(this);
        }
    }
    public void acitve_enemy()
    {
        Debug.Log("µπ¿‘");
        Debug.Log(enemy.Count);
        for (int i=0; i < enemy.Count; i++)
        {
            enemy[i].transform.GetChild(0).gameObject.SetActive(true);
        }
        
        

    }
}
