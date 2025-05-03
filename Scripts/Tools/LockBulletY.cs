using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LockYPosition : MonoBehaviour
{
    public GameObject bullet;
    //private float originalY;
    void Start()
    {
        //originalY = bullet.transform.position.y;
    }


    void Update()
    {
        Vector3 currentPosition = transform.position;
        bullet.transform.position = new Vector3(currentPosition.x, 0, currentPosition.z);
    }
}
