using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : MonoBehaviour
{
    public float miny=2f;
    public float maxy=3f;
    public float maxx=2f;
    public float minx=3f;

    float velocity;
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;

    // Start is called before the first frame update
    void Start()
    {
        miny=transform.position.y;
        maxy=transform.position.y+2;
        minx=transform.position.x;
        maxx=transform.position.x+3;
    }

    // Update is called once per frame
    void Update()
    {
        velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime;
        velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
        transform.Translate(new Vector3(3,0,0) * Time.deltaTime);
    }
}
