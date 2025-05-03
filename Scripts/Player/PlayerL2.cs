using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL2 : PlayerControl
{
    protected override void Shoot()
    {
        RangeAttack();
    }

    private int L2bulletNum = 3;//ɢ������
    private float L2angle = 36;//ɢ���Ƕ�

    //ɢ������
    private void RangeAttack()
    {
        float interal = L2angle / L2bulletNum;
        for (float i = -L2angle / 2; i < L2angle / 2; i = i + interal)
        {
            GameObject gameObject = Instantiate(Bullet);
            gameObject.transform.position = ShotPos.transform.position;
            gameObject.transform.eulerAngles = new Vector3(0, i, 0);
        }
    }
}
