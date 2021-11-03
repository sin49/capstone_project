using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    public bool death_check;//��� üũ
    public int Health_point;
    public int max_hp;
    public int Attack_point;
    public int Defense_point;
    bool can_attack;//1=�����Ҽ��ִ� 0=�����Ҽ�����
    protected float move_speed=1.0f;//�̵��ӵ�
    protected bool untouchable_state;
    protected float untouchable_timer = 0;
    public int direction=1;//ĳ������ ���� 1, -1 �� ���
    
    void Start()
    {
        //Rigidbody2D rgd = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Defense_point > 100)
            Defense_point = 100;
        if (Health_point >= max_hp)
            Health_point = max_hp;
    }
    protected void direction_change()//����ٲٱ� �� ��
    {
        direction *= -1;
        transform.Rotate(0, 180, 0);
        if (transform.rotation.y > 360)
            transform.Rotate(0, -360, 0);
    }
    public void character_lose_health(int dmg)//obj=���� ������Ʈ �ǰݽ� ü���� �Ҵ� ����
    {
        if (!untouchable_state)
        {
            float damage_lose = Defense_point / 100;
            int damage = Mathf.RoundToInt(dmg * (1.0f - damage_lose));//������ ����
            if (damage == 0)
            {
                damage = 1;
            }
            Health_point = Health_point - damage;//ü���� ��������ŭ ����
        }
    }
    public void character_move()//ĳ���� �̵� ��ӿ�
    {
       /* Vector3 move_force = new Vector3(move_speed * direct, 0, 0);
        rgd.AddForce(move_force);
        RaycastHit hit;
        Debug.DrawRay(chr_eye1.transform.position, new Vector3(0.1f, -0.9f, 0), Color.blue);
        if (Physics.Raycast(chr_eye1.transform.position, new Vector3(0.1f, -0.9f, 0), out hit, 2))
        {
            if (hit.collider.CompareTag("platform"))
                direct = direct * -1;
        }
        //if(XXXXXX)//�ڽ��� ���� Ȯ���ϰ� �������ٸ�
        /*direct= direct*-1;
         * 
         */
    }//�⺻ �̵��� �÷����� �ȶ������� �¿� �Դٰ��� ������
    //�������� ó���ϸ� ũ�⸶�� �޶����� �����? ->���� ������ ���ϸ� ��������

    void character_death()//��ӿ�
    {
        //�ʿ��� �̺�Ʈ�� �ۼ�
        
    }
    /*void jump()//���� ���
    {
        /*if (jump_number != 0)
        {
          

            Vector3 jump_vector = new Vector3(0, jump_force, 0);
            rgd.AddForce(jump_vector);
        }*/
    //}
    

}
/*ĳ���Ͱ� �÷����� �ȶ���������...
 ĳ���Ϳ��� "��"�� ����
 "��"�� ĳ���� �ܺο� �浹�������� ����
 "��"�� �ȶ������� �뵵�ܿ� ĳ���Ͱ� ������ �ϰų� ĳ���͸� �Ѵ� �� ���� Ȱ�뵵�� ������
 ĳ������"��"�� �ϳ��� �ƴϴ�->�뵵������ ���� �浹������ ������ �Ѵ�
 �浹������ �ƴ϶� ���ۿ� ���� ray(����)���ε� ���� ����
 */

/*Ǯ�� �ý���
 �Ѿ��� ��Ȱ��ȭ ���ѳ���
 ����Ű-> �Ѿ��� ��ġ�� �̵����ѳ��� Ȱ��ȭ
 ��ų� ȭ�� ������ ������ ��Ȱ��ȭ
 �Ѿ� �±�=bullet
 */
