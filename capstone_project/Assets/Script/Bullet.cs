using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damge=0;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(1,0,0) * 0.1f);
        CameraCheck();
    }
  
    public void CameraCheck()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) DestroyBullet();
        if (pos.x > 1f) DestroyBullet();
        if (pos.y < 0f) DestroyBullet();
        if (pos.y > 1f) DestroyBullet();
    }

    public void DestroyBullet()
    {
        ObjectPool.ReturnObject(this);
    }


}
