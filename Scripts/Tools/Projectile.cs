using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer = 0;//��ʱ��
    public float Speed = 15;//���������ٶ�
    public float hurt = 20;//�˺�
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
