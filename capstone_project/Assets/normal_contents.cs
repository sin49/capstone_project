using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_contents : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    float C_alpha=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        C_alpha = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
