using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public float hurt = 20;//ÉËº¦
    //¼ÆÊ±Æ÷
    private float timer = 0;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 8)
        {
            Destroy(this.gameObject);
        }
        this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
