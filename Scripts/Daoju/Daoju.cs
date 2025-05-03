using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daoju : MonoBehaviour
{
    public float speed;
    private float timer = 0;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }
}
