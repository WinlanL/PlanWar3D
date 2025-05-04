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
        timer += Time.deltaTime;
        this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        if (timer > 8)
        { 
            Destroy(this.gameObject);
        }
    }
}
