using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer = 0;//计时器
    public float Speed = 15;//导弹飞行速度
    public float hurt = 20;//伤害
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
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
