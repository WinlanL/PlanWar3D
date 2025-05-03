using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL1 : Enemy
{
    private void Start()
    {
        //每一个敌人给予不同的血量、速度、伤害
        Init(200, 30, 1);
    }
}
