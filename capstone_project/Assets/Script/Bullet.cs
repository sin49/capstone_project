using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool OutCheck;   //삭제할건지 체크

    public int Damge;     //데미지
    public float Speed;     //총알스피드

    void Update()
    {
        this.transform.Translate(new Vector3(Speed,0,0) * 0.1f);
        CameraCheck();
    }

    public void CameraCheck()   //총알 삭제할건지 체크함수
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (OutCheck)
        {
            if (pos.x < 0f) { OutCheck = false; Invoke("DestroyBullet", 1); }
            else if (pos.x > 1f) { OutCheck = false; Invoke("DestroyBullet", 1); }
            else if (pos.y < 0f) { OutCheck = false; Invoke("DestroyBullet", 1); }
            else if (pos.y > 1f) { OutCheck = false; Invoke("DestroyBullet", 1); }
        }
    }
    

    public void DestroyBullet() //총알삭제
    {
        ObjectPool.ReturnObject(this);
    }


}
