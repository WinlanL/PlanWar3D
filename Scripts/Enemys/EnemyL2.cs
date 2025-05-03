using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL2 : Enemy
{
    private void Start()
    {
        //每一个敌人给予不同的血量、速度、伤害、攻击间隔
        Init(20, 40,50, 4);
    }

    public override void ShootBullet()
    {
        int b01_index = 0;
        GameObject b01 = Instantiate(Bullets[b01_index]);
        b01.transform.position = ShootPoss[b01_index].transform.position;
        b01.transform.rotation = ShootPoss[b01_index].transform.rotation;

        int b02_index = 1;
        GameObject b02 = Instantiate(Bullets[b02_index]);
        b02.transform.position = ShootPoss[b02_index].transform.position;
        b02.transform.rotation = ShootPoss[b02_index].transform.rotation;
    }


    //计算敌人L2的分数
    //public override void caScore()
    //{
    //    GameManager.Instance.SetScore(40);
    //}
}
