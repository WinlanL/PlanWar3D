using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Random.Range(0f, 10f));
    }
}
