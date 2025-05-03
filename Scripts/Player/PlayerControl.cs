using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerControl : MonoBehaviour
{
    [Header("Tilt Settings")]
    [SerializeField] private float maxTiltAngle = 30f; // 最大倾斜角度
    [SerializeField] private float tiltSpeed = 60f;    // 倾斜速度（度/秒）
    [SerializeField] private float returnSpeed = 50f;  // 回正速度（度/秒）
    private float currentTiltAngle = 0f; // 当前倾斜角度
    private float speed = 20;
    public float hp = 100;

    public GameObject Bullet;
    public GameObject ShotPos;
    private float timer = 0;

    private KeyInterval J_Key=new KeyInterval(KeyCode.J,0.5f);
    private KeyInterval K_Key = new KeyInterval(KeyCode.K, 0.4f);

    //private int bulletNum = 6;//散弹数量
    //private float angle = 50;//散弹角度

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(hp);
        if (hp <= 0)
        {
            die();
            hp = 100;
        }


        HandleTiltInput();
        ApplyTilt();
        attack();
    }
    private void HandleTiltInput()
    {
        // 获取左右方向键输入
        float horizontalInput = Input.GetAxis("Horizontal");
        //左右移动
        //if (horizontalInput != 0)
        //{
        //    transform.Translate(new Vector3(horizontalInput, 0, 0) * Time.deltaTime * speed, Space.World);
        //    NextPos = transform.position;
        //    if (NextPos.x > 27f || NextPos.x < -27f)
        //    {
        //        NextPos.x=transform.position.x;
        //    }
        //    Debug.Log(NextPos);
        //    transform.position = NextPos;
        //}
        Vector3 NextPos = transform.position + new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
        if (NextPos.x > 28f || NextPos.x < -28f)
        {
            NextPos.x = transform.position.x;
        }
        transform.position = NextPos;

        // 根据输入调整倾斜角度
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // 计算目标倾斜角度
            float targetTiltAngle = -maxTiltAngle * Mathf.Sign(horizontalInput);

            // 平滑过渡到目标角度
            currentTiltAngle = Mathf.MoveTowards(currentTiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);
        }
        else
        {
            // 如果没有输入，逐渐回正
            currentTiltAngle = Mathf.MoveTowards(currentTiltAngle, 0f, returnSpeed * Time.deltaTime);
        }
    }

    private void ApplyTilt()
    {
        // 获取当前旋转角度
        Vector3 currentRotation = transform.eulerAngles;

        // 更新 Z 轴旋转角度
        currentRotation.z = currentTiltAngle;

        // 应用新的旋转角度
        transform.eulerAngles = currentRotation;
    }

    //攻击
    private void attack()
    { 
        J_Key.IntervaleDown(() => 
        {
            Shoot();
        },null);
        //K_Key.IntervaleDown(() =>
        //{
        //    //发射子弹
        //    /*GameObject gameObject = Instantiate(Bullet);
        //    gameObject.transform.position = ShotPos.transform.position + new Vector3(-0.8f, 0, 0);

        //    GameObject gameObject1 = Instantiate(Bullet);
        //    gameObject1.transform.position = ShotPos.transform.position + new Vector3(0.8f, 0, 0);*/
        //    RangeAttack();
        //},null);

    }

    protected virtual void Shoot()
    {
        //发射子弹
        GameObject gameObject = Instantiate(Bullet);
        gameObject.transform.position = ShotPos.transform.position;
    }



    //散弹
    //private void RangeAttack()
    //{
    //    float interal = angle / bulletNum;
    //    for (float i = -angle/2; i < angle/2; i=i+interal)
    //    { 
    //        GameObject gameObject= Instantiate(Bullet);
    //        gameObject.transform.position = ShotPos.transform.position;
    //        gameObject.transform.eulerAngles = new Vector3(0,i, 0);
    //    }
    //}

    //碰到物体
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //计算伤害
            hp = hp - collision.gameObject.GetComponent<Bullet>().hurt;
            Debug.Log("dssdsds" + hp);
        }
    }

    //玩家死亡
    private void die()
    {
        //播放结算页面
        Debug.Log("玩家死亡");
    }
}
