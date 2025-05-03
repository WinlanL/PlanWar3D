using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL2 : PlayerControl
{
    protected override void Shoot()
    {
        RangeAttack();
    }

    private int bulletNum = 6;//ɢ������
    private float angle = 50;//ɢ���Ƕ�

    //ɢ������
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
}
