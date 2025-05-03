using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyInterval 
{
    private float invoke; //���ʱ��
    private float invokeTimer;  //���ʱ���ʱ��
    private KeyCode keyCode;
    private float timer = 0;  //������ʱ��

    public KeyInterval(KeyCode keyCode, float invoke)
    { 
        this.keyCode = keyCode;
        this.invoke = invoke;
        this.invokeTimer = invoke;
    }
    //Action  ����ָ��
    public void IntervaleDown(Action action, Action actionEnd)
    {
        if (Input.GetKey(keyCode))
        {
            invokeTimer += Time.deltaTime;
            if (invokeTimer >= invoke)
            {
                action();
                invokeTimer = 0;
            }
        }
        if (Input.GetKeyUp(keyCode))
        {
            if (timer > invoke)
            {
                invokeTimer = invoke;
                timer = 0;
            }
            invokeTimer = invoke;
            if (actionEnd != null)
            {
                actionEnd();
            }
        }
        timer += Time.deltaTime;
    }
}
