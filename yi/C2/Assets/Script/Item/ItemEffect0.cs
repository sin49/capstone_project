using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect0 : MonoBehaviour
{
    public static ItemEffect0 item0to10;
    bool[] code_effect;
    // Start is called before the first frame update
    void Awake()
    {
        item0to10 = this;
        code_effect = new bool[10];
    }

    
    public void effect(int code)
    {
        switch (code)
        {
            case 0:
                if (!code_effect[0])
                {
                    Debug.Log(code + "¿Â¬¯");
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code_effect[0] = true;
                }
                break;
            case 1:
                if (!code_effect[1])
                {
                    Debug.Log(code + "¿Â¬¯");
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code_effect[1] = true;
                }
                break;
            case 2:
                if (!code_effect[2])
                {
                    Debug.Log(code + "¿Â¬¯");
                    Player_status.p_status.set_max_HP(20);
                    Player_status.p_status.set_hp(20);
                    code_effect[2] = true;
                }
                break;
        }
    }
    public void un_effect(int code)
    {
        switch (code)
        {
            case 0:
                if (code_effect[0])
                {
                    Debug.Log(code + "«ÿ¡¶");
                    Player_status.p_status.set_max_HP(-20);
                    Player_status.p_status.set_hp(-20);
                    code_effect[0] = false;
                }
                break;
            case 1:
                if (code_effect[1])
                {
                    Debug.Log(code + "«ÿ¡¶");
                    Player_status.p_status.set_max_HP(-20);
                    Player_status.p_status.set_hp(-20);
                    code_effect[1] = false;
                }
                break;
            case 2:
                if (code_effect[2])
                {
                    Debug.Log(code + "«ÿ¡¶");
                    Player_status.p_status.set_max_HP(-20);
                    Player_status.p_status.set_hp(-20);
                    code_effect[2] = false;
                }
                break;
        }
    }
   
}
