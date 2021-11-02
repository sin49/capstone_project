using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    static public Vector2 center;
    public Vector2 size;

    float height;
    float width;

    
    private void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height; 
    }

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            //transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

            float lx = size.x * 0.5f - width;
            float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

            float ly = size.y * 0.5f - height;
            float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center,size);
    }
}