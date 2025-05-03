using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject gamePanel;

    private RaySixDirCollision raySixDirCollision;
    
    public GameObject Player;

    private Rigidbody rigidbody;

    //敌机参数设置
    private float hp;//血量
    private float speed = 30;//速度
    private float hurt;//伤害
    private float attackInterval = 1; //两次攻击间隔

    //void Start()
    //{
    //    Init(200, 30, 50，10);
    //}

    protected void Init(float hp, float speed, float hurt, float attackInterval)
    {
        this.hp = hp;
        this.speed = speed;
        this.hurt = hurt;
        this.attackInterval = attackInterval;

        rigidbody = GetComponent<Rigidbody>();
        //除了第6层之外，其他层都可以检查
        raySixDirCollision = new RaySixDirCollision(~(1 << 9));
        //添加射线层
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
            //敌机死亡后的处理
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
    //敌机移动
    public void move()
    {
        //this.transform.eulerAngles = new Vector3(-rigidbody.velocity.z * 3, transform.eulerAngles.y, rigidbody.velocity.x * 10);
        //Debug.Log(rigidbody.velocity);
        //看向玩家发射子弹
        //延迟转向,与玩家距离大于30时，追踪玩家
        float dis = Vector3.Distance(transform.position, Player.transform.position);
        if (dis >= 30)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), 0.005f);
        }
        //与玩家距离小于30时，朝前飞行
        else
        {
            transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
        }
        //飞出画面外时，销毁
        if (this.transform.position.z < -3)
        {
            Destroy(this.gameObject);
        }

        if(this.transform.position.y > 0 )
        {
            rigidbody.AddForce(Vector3.down * 10);
        }
        if (this.transform.position.y < 0)
        {
            rigidbody.AddForce(Vector3.up * 10);
        }
        if (this.transform.position.x > 28)
        {
            rigidbody.AddForce(Vector3.left * 30);
        }
        if (this.transform.position.x < -28)
        {
            rigidbody.AddForce(Vector3.right * 30);
        }
        //向前移动
        rigidbody.AddRelativeForce(Vector3.forward * speed);
        //敌人左右边界
        //Vector3 NextPos = transform.position;
        //if (NextPos.x > 28f || NextPos.x < -28f)
        //{
        //    NextPos.x = transform.position.x;
        //}
        //transform.position = NextPos;

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

    //死亡
    private void die()
    {
        //敌机死亡后旋转下坠
        rigidbody.AddForceAtPosition(Vector3.up * -2, transform.position + new Vector3(5, 0, 0), ForceMode.Impulse);
        //生成一个爆炸  todo
        rigidbody.useGravity = true;
        isDie = true;
        //计算分数
        //caScore();
    }

    public virtual void caScore()
    {
        GameManager.Instance.SetScore(20);
    }


    //攻击
    public GameObject[] Bullets;//子弹
    public GameObject[] ShootPoss;

    private float attackTimer = 0;
    private void attack()
    { 
        attackTimer += Time.deltaTime;
        if (attackTimer > attackInterval)
        {
            //调用发射子弹
            ShootBullet();
            attackTimer = 0;
        }
    }
    //发射子弹
    public virtual void ShootBullet()
    {
        int index = 0;
        GameObject obj = Instantiate(Bullets[index]);
        obj.transform.position = ShootPoss[index].transform.position;
        obj.transform.rotation = ShootPoss[index].transform.rotation;
    }



    //碰到物体
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //播放爆炸特效  todo

            //计算伤害
            hp = hp - collision.gameObject.GetComponent<Projectile>().hurt;
            Debug.Log(hp);

        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
