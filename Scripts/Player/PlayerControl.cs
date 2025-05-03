using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Mime;


public class PlayerControl : MonoBehaviour
{
    [Header("Tilt Settings")]
    [SerializeField] private float maxTiltAngle = 30f; // �����б�Ƕ�
    [SerializeField] private float tiltSpeed = 60f;    // ��б�ٶȣ���/�룩
    [SerializeField] private float returnSpeed = 50f;  // �����ٶȣ���/�룩
    private float currentTiltAngle = 0f; // ��ǰ��б�Ƕ�
    private float speed = 20;
    public float hp = 100;

    public GameObject Bullet;
    public GameObject ShotPos;
    private float timer = 0;

    private KeyInterval Space_Key=new KeyInterval(KeyCode.Space,1f);
    private KeyInterval K_Key = new KeyInterval(KeyCode.K, 0.5f);

    //private int bulletNum = 6;//ɢ������
    //private float angle = 50;//ɢ���Ƕ�

    
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
        // ��ȡ���ҷ��������
        float horizontalInput = Input.GetAxis("Horizontal");
        //�����ƶ�
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

        // �������������б�Ƕ�
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            // ����Ŀ����б�Ƕ�
            float targetTiltAngle = -maxTiltAngle * Mathf.Sign(horizontalInput);

            // ƽ�����ɵ�Ŀ��Ƕ�
            currentTiltAngle = Mathf.MoveTowards(currentTiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);
        }
        else
        {
            // ���û�����룬�𽥻���
            currentTiltAngle = Mathf.MoveTowards(currentTiltAngle, 0f, returnSpeed * Time.deltaTime);
        }
    }

    private void ApplyTilt()
    {
        // ��ȡ��ǰ��ת�Ƕ�
        Vector3 currentRotation = transform.eulerAngles;

        // ���� Z ����ת�Ƕ�
        currentRotation.z = currentTiltAngle;

        // Ӧ���µ���ת�Ƕ�
        transform.eulerAngles = currentRotation;
    }

    //����
    private void attack()
    { 
        Space_Key.IntervaleDown(() => 
        {
            Shoot();
        },null);
        K_Key.IntervaleDown(() =>
        {
            //�����ӵ�
            /*GameObject gameObject = Instantiate(Bullet);
            gameObject.transform.position = ShotPos.transform.position + new Vector3(-0.8f, 0, 0);

            GameObject gameObject1 = Instantiate(Bullet);
            gameObject1.transform.position = ShotPos.transform.position + new Vector3(0.8f, 0, 0);*/
            RangeAttack();
        }, null);

    }

    protected virtual void Shoot()
    {
        //�����ӵ�
        GameObject gameObject = Instantiate(Bullet);
        gameObject.transform.position = ShotPos.transform.position;
    }

    private int bulletNum = 6;//ɢ������
    private float angle = 50;//ɢ���Ƕ�

    //ɢ��
    private void RangeAttack()
    {
        float interal = angle / bulletNum;
        for (float i = -angle / 2; i < angle / 2; i = i + interal)
        {
            GameObject gameObject = Instantiate(Bullet);
            gameObject.transform.position = ShotPos.transform.position;
            gameObject.transform.eulerAngles = new Vector3(0, i, 0);
        }
    }

    //��������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //�����ӵ�
            Destroy(collision.gameObject);
            //�����˺�
            hp = hp - collision.gameObject.GetComponent<Projectile>().hurt;
            //Debug.Log("dssdsds" + hp);
        }
        //�����л���ײ���
        if (collision.gameObject.tag == "Enemy")
        {
            hp = hp - 50;
        }
        //����뽱������ײ���
        if (collision.gameObject.tag == "Daoju")
        {
            Destroy(collision.gameObject);
            Debug.Log("nb666");//�����﹦��
        }
    }

    //�������
    private void die()
    {
        //���Ž���ҳ��
        Debug.Log("�������");
    }
}
