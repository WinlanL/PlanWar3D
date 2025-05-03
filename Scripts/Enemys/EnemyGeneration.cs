using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject Player;

    public Transform Rpoint01;
    public Transform Rpoint02;

    private int rangex = 0;
    private int rangez = 0;

    public GameObject[] enemys;
    private float timer = 0;

    void Start()
    {
        rangex = (int)((Rpoint02.position.x - Rpoint01.position.x) / 10);
        rangez = (int)((Rpoint02.position.z - Rpoint01.position.z) / 10);
    }

    public int enemyCount = 1;

    void Update()
    {
        //按批次随机生成敌人
        GameObject[] curEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (curEnemys.Length == 0)
        {
            for (int i = 0; i < Random.Range(1,4); i++)
            {
                int enemyIndex = Random.Range(0, 2);
                float rx = Random.Range(0, rangex) * 10;
                float rz = Random.Range(0, rangez) * 10;
                float x = Rpoint01.position.x + rx;
                float z = Rpoint02.position.z + rz;
                GameObject obj = Instantiate(enemys[enemyIndex]);
                obj.transform.position = new Vector3(x+i, 0, z-i);
                obj.GetComponent<Enemy>().Player = Player;
            }
            
        }
    }
}


