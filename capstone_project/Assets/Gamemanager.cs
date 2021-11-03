using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_create;
    GameObject Player_obj;
    public room_controller room_controller;
    public GameObject Player_spawn;
    public bool spawn_check;
    
    private void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        room_controller = GameObject.Find("map_system").GetComponent<room_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (room_controller.map_making_complete)
        {
            if (Player_spawn == null)
            {
                Player_spawn=GameObject.Find("Player spawner");
            }
            if (Player_create == null)
            {
                Player_create = Instantiate(Player);
                Player_obj = Player_create.transform.GetChild(0).gameObject;
            }

            if (!spawn_check && Player_create != null&& Player_spawn!=null) {
                Player_obj.transform.position = Player_spawn.transform.position;
                Player_obj.SetActive(true);
                spawn_check = true;
                        }
            
        }
    }
}
