using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    //玩家
    public GameObject player;
    private Vector3 offset;
    public float speed = 3;
    void Start()
    {
        //调整偏移，摄像头居中
        offset = transform.position - player.transform.position;
        offset = new Vector3(0, offset.y, offset.z);
    }

    int state = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeView(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeView(1);
        }

        if (state == 0)
        {
            Vector3 targetPosition = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (state == 1)
        {
            Vector3 targetPosition = offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(targetPosition,transform.position)<=0.01)
            {
                state = -1;
            }
        }
    }
    private Vector3[] offsets = new Vector3[] { new Vector3(0, 6, -8), new Vector3(0, 30, 14) };
    private Vector3[] cameraRotation = new Vector3[] { new Vector3(20, 0, 0), new Vector3(90, 0, 0) };

    private void ChangeView(int i)
    {
        offset = offsets[i];
        Camera.main.transform.eulerAngles = cameraRotation[i];
        state = i;
    }
}
