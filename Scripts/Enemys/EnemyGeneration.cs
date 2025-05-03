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

    void Start()
    {
        rangex = (int)((Rpoint02.position.x - Rpoint01.position.x) / 10);
        rangez = (int)((Rpoint02.position.z - Rpoint01.position.z) / 10);
    }

    public int enemyCount = 1;

    void Update()
    {
        GameObject[] curEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (curEnemys.Length == 0)
        {
            int indexMax = enemyCount > enemys.Length ? enemys.Length : enemyCount;//最大值索引
            Debug.Log(indexMax);
            for (int i = 0; i < enemyCount; i++)
            {
                int enemyIndex = Random.Range(0, indexMax);

                float rx = Random.Range(0, rangex) * 10;
                float rz = Random.Range(0, rangez) * 10;
                float x = Rpoint01.position.x + rx;
                float z = Rpoint02.position.z + rz;
                GameObject obj = Instantiate(enemys[enemyIndex]);
                obj.transform.position = new Vector3(x, 0, z);
                obj.GetComponent<Enemy>().Player = Player;
                //obj.GetComponent<EnemyL1>().Player = Player;
            }
            enemyCount++;

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    float rx = Random.Range(0, rangex) * 10;
        //    float rz = Random.Range(0, rangez) * 10;
        //    float x = Rpoint01.position.x + rx;
        //    float z = Rpoint02.position.z + rz;
        //    //Debug.Log("rx:" + rx);
        //    //Debug.Log("rz:" + rz);
        //    //Debug.Log("x:" + x);
        //    //Debug.Log("z:" + z);
        //    GameObject obj = Instantiate(enemy);
        //    obj.transform.position = new Vector3(x, 0, z);

        }
    }
}
