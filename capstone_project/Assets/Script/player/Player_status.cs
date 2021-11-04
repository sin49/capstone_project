using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_status : MonoBehaviour
{
    public static Player_status p_status;
    public int layout_num;//레이아웃 숫자
    [SerializeField]
    private int original_MaX_HP;//최대 체력 원본
    private int MaX_HP_bonus;//최대 체력 가산점
    private int HP;//현재 체력
    private int original_Defense;//방어력 원본
    private int Defense_bonus;//방어력 가산점
    private float original_untouchable_time;//무적시간 원본 
    private float untouchable_time_bonus;//무적시간 보너스
    float original_speed;
    float speed_bonus;
    [Header("jump")]
    private float original_jump_force;//점프높이 원본
    float jump_force_bonus;//점프높이 가산점
    private int original_max_jump_count;//점프 횟수 원본
    int max_jump_count_bonus;//점프횟수 가산점
    [Header("gun")]
    private float original_firedelay;//원본 발사 속도
    private float firedelay_bonus;//발사속도 보너스
    private int original_Gun_Atk;//총 공격력 원본
    private int Gun_Atk_bonus;//총 공격력 가산점
    private float original_bullet_speed;//총알 속도 원본
    private float bullet_speed_bonus;//총알 속도 가산점
    private bool volly;//연발,단발
    [Header("dash")]
    float original_dash_force;//대쉬길이 원본
    float dash_force_bonus;//대쉬길이 가산점
    int original_max_dash_count = 1;//대쉬횟수 원본
    int max_dash_count_bonus;//대쉬횟수 가산점
    //List<Dictionary<string, object>> P_Data = CSVReader.Read("playerStatus");
    //csv로  original 값 정하면 될듯?
    public void set_layout()
    {
        //Debug.Log(P_Data[layout_num]["MaxHP"].ToString());
        /*original_MaX_HP = int.Parse(P_Data[layout_num]["MaxHP"].ToString());
         original_Defense= int.Parse(P_Data[layout_num]["Defense"].ToString());
         original_untouchable_time=float.Parse(P_Data[layout_num]["Untouchabletime"].ToString());
         original_jump_force= float.Parse(P_Data[layout_num]["Jumpforce"].ToString());
         original_max_jump_count=int.Parse(P_Data[layout_num]["Jumpcount"].ToString());
         original_firedelay=float.Parse(P_Data[layout_num]["Firedelay"].ToString());
         original_Gun_Atk=int.Parse(P_Data[layout_num]["Gunatk"].ToString());
         original_bullet_speed=float.Parse(P_Data[layout_num]["Bulletspeed"].ToString());
         volly=bool.Parse(P_Data[layout_num]["Volly"].ToString());
         original_dash_force=float.Parse(P_Data[layout_num]["Dashforce"].ToString());
         original_max_dash_count=int.Parse(P_Data[layout_num]["Dashcount"].ToString());*/
        original_MaX_HP = 100;
        HP = get_max_hp();
        original_Defense = 0;
        original_untouchable_time = 1;
        original_jump_force = 20;
        original_max_jump_count = 1;
        original_firedelay = 1;
        original_Gun_Atk = 10;
        original_bullet_speed = 10;
        volly = true;
        original_dash_force = 20;
        original_max_dash_count = 1;
        original_speed = 10;
        
    }
    public float get_firedelay()
    {
        return original_firedelay + firedelay_bonus;
    }
    public int get_atk()
    {
        return original_Gun_Atk + Gun_Atk_bonus;
    }
    public float get_bullet_speed()
    {
        return original_bullet_speed + bullet_speed_bonus;
    }
    public bool get_volly()
    {
        return volly;
    }
    public float get_dash_force()
    {
        return original_dash_force + dash_force_bonus;
    }
    public float get_speed()
    {
        return original_speed + speed_bonus;
    }
    void Awake()
    {
       
        p_status = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int get_max_hp()
    {
        return original_MaX_HP+MaX_HP_bonus;
    }
    public int get_hp()
    {
        return HP;
    }
    public void set_max_HP(int i)
    {
        MaX_HP_bonus += i;
    }
    public void set_hp(int i)
    {
        HP += i;
    } 
    public float get_untouchable_time()
    {
        return original_untouchable_time + untouchable_time_bonus;
    }
    public int get_dash_count()
    {
        return original_max_dash_count+max_dash_count_bonus;
    }
    public int get_jump_count()
    {
        return original_max_jump_count + max_jump_count_bonus;
    }
    public float get_jump_force()
    {
        return original_jump_force + jump_force_bonus;
    }
    public int get_defense_point()
    {
        return original_Defense + Defense_bonus;
    }
}
