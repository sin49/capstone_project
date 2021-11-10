using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect0 : MonoBehaviour
{
    public static ItemEffect0 item0to10;
    bool code0_bool;
    // Start is called before the first frame update
    void Awake()
    {
        item0to10 = this;
    }

    public void effect(int code)
    {
        switch (code)
        {
            case 0:
                if (!code0_bool)
                {
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code0_bool = true;
                }
                break;
            case 1:
                if (!code0_bool)
                {
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code0_bool = true;
                }
                break;
            case 2:
                if (!code0_bool)
                {
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code0_bool = true;
                }
                break;
        }
    }
}
