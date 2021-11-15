using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Follow_Path : MonoBehaviour
{
    Rigidbody _rigidbody;

    public enum loop { One_pass, Loop, Ping_Pong };
    [Tooltip("Select the kind of wave function used to calculate the movement")]
    public loop Loop;

    [Header("List of locations")]
    [Tooltip("Location data must be stored in this format. x,y,z eg: 1.01,2.02,3.03\n(No spaces)")]
    public List<string> details = new List<string>();

    public List<Vector4> details2 = new List<Vector4>();
    public float speed = 1.7f;
    
    private int list_location = 0;
    private bool ping_pong_direction = true; //true = forward, false = backwards
    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        
        //Names.Add("1.1,2.22,3.33");
        //Names.Add("4.44,5.55,6.66");
        //Debug.Log(Names[1]);
        //string[] arr = Names[1].Split(new char[] { ',' });
        //Debug.Log(float.Parse(arr[1]) + 1.0f);
        //Debug.Log(details.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Debug.Log(list_location);
        if (list_location != -1)
        {
            string[] data = details[list_location].Split(new char[] { ',' });

            x = float.Parse(data[0]);
            y = float.Parse(data[1]);
            z = float.Parse(data[2]);

            

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, y, z), speed * Time.deltaTime);

            

        }
        switch (Loop)
        {
            case loop.One_pass:
                if (transform.position == new Vector3(x, y, z) && list_location != -1)
                    list_location++;

                if (list_location == details.Count)
                {
                    list_location = -1;
                    
                }
                break;

            case loop.Loop:
                if (transform.position == new Vector3(x, y, z))
                    list_location++;

                if (list_location == details.Count)
                    list_location = 0;
                break;

            case loop.Ping_Pong:
                if (transform.position == new Vector3(x,y,z))
                {
                    if (ping_pong_direction)
                        list_location++;
                    else
                        list_location--;

                    if (list_location == details.Count && ping_pong_direction)
                    {
                        ping_pong_direction = false;
                        list_location--;
                    }  
                       
                   if (list_location == 0 && ping_pong_direction == false)
                   {
                        ping_pong_direction = true;
                        
                   }
                }
                break;
        }
    }

}
