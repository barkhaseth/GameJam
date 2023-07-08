using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe1 : MonoBehaviour
{
    public float min=2f;
    public float max=3f;
    //bool moving;
    //Vector2 finalPos;
    //public float amp = 3f;
    //public float freq = 3f;
   
    // Use this for initialization
    private void Start () {
       
        min=transform.position.y;
        max=transform.position.y+3;
        //initPos = transform.position;
   
    }
   
    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*2,max-min)+min, transform.position.z);
        //transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
        /*
        if(Input.GetMouseButtonDown(0)) {
            moving = true;
        }
        if(moving && (Vector2)transform.position)
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*2,max-min)+min, transform.position.z);
        */
    }
}
