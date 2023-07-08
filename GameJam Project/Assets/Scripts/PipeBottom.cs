using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBottom : MonoBehaviour
{
    public float min=2f;
    public float max=3f;
    private bool moving;
    private Vector2 finalPos;
    private Vector2 initPos;
    //public float amp = 3f;
    //public float freq = 3f;
   
    // Use this for initialization
    private void Start () {
       
        min=transform.position.y;
        max=transform.position.y+3;
        finalPos = transform.position;
        initPos = transform.position;
   
    }
   
    // Update is called once per frame
    void Update () {
        //transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time*2,max-min)+min);
        //transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
        /*
        if(Input.GetMouseButtonDown(0)) {
            //transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time*2,0.001f)+min);
            finalPos = new Vector2(transform.position.x, transform.position.y+3);
            moving = true;
        }
        if(moving && (Vector2)transform.position != finalPos){
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time*2,max-min)+min);
        } else {
            moving = false;
            transform.position = finalPos;
        }
        */
        
    }
}
