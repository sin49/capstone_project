using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room_contents_controller : MonoBehaviour
{
    public GameObject[] spawn_contents;
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
        if (this_room.room_element == 1)
        {
            int random = Random.Range(0, spawn_contents.Length);
            Debug.Log("난수:"+random);
            Debug.Log("길이:" + spawn_contents.Length);
            GameObject a=Instantiate(spawn_contents[random],this.transform.position,Quaternion.identity);
            a.transform.SetParent(this.transform);
            check_room_contents = true;
        }
    }
}
