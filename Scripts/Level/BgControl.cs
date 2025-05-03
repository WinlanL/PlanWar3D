using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{

    public Transform[] Bgs;
    public float bgSize = 63;
    private float allSize = 0;
    public float Speed = 3;
    void Start()
    {
        allSize = Bgs.Length * bgSize;
    }

    
    void Update()
    {
        bgMove();
    }
    private void bgMove(float dir = -1)
    {
        //循环遍历每一个背景
        for (int i = 0; i < Bgs.Length; i++)
        {
            Bgs[i].transform.Translate(new Vector3(0, 0, dir * Speed * Time.deltaTime));
            if (Bgs[i].transform.position.z <= dir * bgSize)
            {
                Bgs[i].position = Bgs[i].position + new Vector3(0, 0, -dir * allSize);
            }
        }
    }
}
