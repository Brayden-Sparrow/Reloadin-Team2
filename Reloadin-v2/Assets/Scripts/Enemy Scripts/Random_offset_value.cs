using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Random_offset_value : MonoBehaviour
{
    public float myoffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myoffset = Random.Range(0.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public float get_value()
    {
        return myoffset;
    }
}
