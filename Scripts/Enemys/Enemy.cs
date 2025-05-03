using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject gamePanel;

    private RaySixDirCollision raySixDirCollision;
    
    public GameObject Player;

    private Rigidbody rigidbody;

    //�л���������
    private float hp;//Ѫ��
    private float speed = 30;//�ٶ�
    private float hurt;//�˺�
    private float attackInterval = 1; //���ι������

    //void Start()
    //{
    //    Init(200, 30, 10);
    //}

    protected void Init(float hp, float speed, float hurt, float attackInterval)
    {
        this.hp = hp;
        this.speed = speed;
        this.hurt = hurt;
        this.attackInterval = attackInterval;

        rigidbody = GetComponent<Rigidbody>();
        //���˵�6��֮�⣬�����㶼���Լ��
        raySixDirCollision = new RaySixDirCollision(~(1 << 9));
        //������߲�
        raySixDirCollision.AddRayLayer(Vector3.zero, 2, Color.red);
        raySixDirCollision.AddRayLayer(new Vector3(0, 0, 1.5f), 3, Color.green);

        raySixDirCollision.SetDistance(0, DRI.LEFT, 5);
        raySixDirCollision.SetDistance(0, DRI.RIGHT, 5);

        raySixDirCollision.SetDistance(1, DRI.LEFT, 5);
        raySixDirCollision.SetDistance(1, DRI.RIGHT, 5);   
    }


    private bool isDie = false;
    private float timer = 0;
    void Update()
    {
        raySixDirCollision.RaySixDirCollisionUpdate(this.transform);
        if (hp <= 0 && !isDie)
        {
            Debug.Log("die");
            die();
        }
        if (isDie)
        {
            //�л�������Ĵ���
            //Destroy(this.gameObject, 3);
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Destroy(this.gameObject);
            }
        }
        if (!isDie)
        {
            //Debug.Log("sdfsfsf");
            move();
            attack();
        }
        
    }
    //�л��ƶ�
    public void move()
    {
        this.transform.eulerAngles = new Vector3(-rigidbody.velocity.z * 3, transform.eulerAngles.y, rigidbody.velocity.x * 10);
        //Debug.Log(rigidbody.velocity);
        //������ҷ����ӵ�
        //�ӳ�ת��
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(Player.transform.position - transform.position), 0.005f);

        if(this.transform.position.y > 0 )
        {
            rigidbody.AddForce(Vector3.down * 10);
        }
        if (this.transform.position.y < 0)
        {
            rigidbody.AddForce(Vector3.up * 10);
        }
        //�л�����ұ���һ�����룬������ҵľ������20��ǰ���ƶ�
        float dis = Vector3.Distance(transform.position, Player.transform.position);
        if (dis >= 20)
        {
            //Vector3.forward = new Vector3(0,0,1)
            //this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            rigidbody.AddRelativeForce(Vector3.forward * speed);
        }
        if (dis < 18)
        {
            //this.transform.Translate(-Vector3.forward * speed * Time.deltaTime);

            rigidbody.AddRelativeForce(Vector3.back * speed);
        }

        raySixDirCollision.SixRaycast((dir, hit) =>
        {
            switch (dir)
            { 
                case DRI.FORNT:
                    rigidbody.AddRelativeForce(Vector3.right * 25);
                    break;
                case DRI.LEFT:
                    rigidbody.AddRelativeForce(Vector3.right * 25);
                    break;
                case DRI.RIGHT:
                    rigidbody.AddRelativeForce(Vector3.left * 25);
                    break;
                default:
                    break;
            }
        },null);
    }

    //����
    private void die()
    {
        //�л���������ת��׹
        rigidbody.AddForceAtPosition(Vector3.up * -2, transform.position + new Vector3(5, 0, 0), ForceMode.Impulse);
        //����һ����ը  todo
        rigidbody.useGravity = true;
        isDie = true;
        //�������
        caScore();
    }

    public virtual void caScore()
    {
        GameManager.Instance.SetScore(20);
    }


    //����
    public GameObject[] Bullets;//�ӵ�
    public GameObject[] ShootPoss;

    private float attackTimer = 0;
    private void attack()
    { 
        attackTimer += Time.deltaTime;
        if (attackTimer > attackInterval)
        {
            //���÷����ӵ�
            ShootBullet();
            attackTimer = 0;
        }
    }
    //�����ӵ�
    public virtual void ShootBullet()
    {
        int index = 0;
        GameObject obj = Instantiate(Bullets[index]);
        obj.transform.position = ShootPoss[index].transform.position;
        obj.transform.rotation = ShootPoss[index].transform.rotation;
    }



    //��������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //�����ӵ�
            Destroy(collision.gameObject);
            //���ű�ը��Ч  todo

            //�����˺�
            hp = hp - collision.gameObject.GetComponent<Bullet>().hurt;
            Debug.Log(hp);

        }
    }
}
