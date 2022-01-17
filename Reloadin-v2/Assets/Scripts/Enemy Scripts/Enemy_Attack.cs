using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private float speed = 5f;

    public GameObject Player;

    private float Player_x;
    private float Player_z;

    private float my_x;
    private float my_z;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_x = Player.transform.position.x;
        Player_z = Player.transform.position.z;

        my_x = transform.position.x;
        my_z = transform.position.z;

        distance = Get_Distance();
        

        if (distance < 15f)
        {
            transform.LookAt(new Vector3(Player_x, 1.33f, Player_z));
            transform.position += transform.forward * Time.deltaTime * speed;

            //Debug.Log(transform.forward * Time.deltaTime * speed);
        }

    }

    private float Get_Distance()
    {
        float my_Distance;

        my_Distance = Mathf.Sqrt((Mathf.Abs(Player_x - my_x) * Mathf.Abs(Player_x - my_x)) + (Mathf.Abs(Player_z - my_z) * Mathf.Abs(Player_z - my_z)));

        return my_Distance;
    } 
    

}
