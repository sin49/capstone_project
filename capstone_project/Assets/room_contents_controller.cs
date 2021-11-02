using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_contents_controller : MonoBehaviour
{
    public GameObject[] spawn_contents;
    public GameObject[] normal_contents;
    public room this_room;
    public bool check_room_contents;

    
    // Start is called before the first frame update
    void Start()
    {
        this_room = gameObject.GetComponentInParent<room>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!check_room_contents)
        {
            active_contents();
        }
    }
    void active_contents()
    {
        int random;
        switch (this_room.room_element)
        {
            case 1:
                random = Random.Range(0, spawn_contents.Length);
                Debug.Log("����:" + random);
                Debug.Log("����:" + spawn_contents.Length);
                GameObject a = Instantiate(spawn_contents[random], this.transform.position, Quaternion.identity);
                a.transform.SetParent(this.transform);
                check_room_contents = true;
                break;
            case 2:
                random = Random.Range(0, normal_contents.Length);
                Debug.Log("����:" + random);
                Debug.Log("����:" + normal_contents.Length);
                GameObject b = Instantiate(normal_contents[random], this.transform.position, Quaternion.identity);
                b.transform.SetParent(this.transform);
                check_room_contents = true;
                break;
        }
        
    }
}
