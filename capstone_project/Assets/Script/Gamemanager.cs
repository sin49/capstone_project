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
    public static Gamemanager GM;
    static int stage;//0 게임 시작 안함 1~....게임중
    private void Awake()
    {
        GM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        room_controller = GameObject.Find("map_system").GetComponent<room_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stage != 0)
        {
            on_game();
        }
    }
    void on_game()
    {
        if (room_controller.map_making_complete)
        {
            if (Player_spawn == null)
            {
                Player_spawn = GameObject.Find("Player spawner");
            }
            if (Player_create == null)
            {
                Player_create = Instantiate(Player);
                Player_obj = Player_create.transform.GetChild(0).gameObject;
            }

            if (!spawn_check && Player_create != null && Player_spawn != null)
            {
                Player_obj.transform.position = Player_spawn.transform.position;
                Player_obj.SetActive(true);
                spawn_check = true;
            }

        }
    }
    public Transform get_player_transform()
    {
        return Player_obj.transform;
    }
}
