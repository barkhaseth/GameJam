using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperPillar2Script : MonoBehaviour
{
    Rigidbody2D rb;
    static bool DowntimeBetweenAttacks = false;
    public float CrushingSpeed = 25f;
    bool startposY = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (DowntimeBetweenAttacks == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                DowntimeBetweenAttacks = true;
                startposY = false;
                rb.AddForce(CrushingSpeed * Vector2.down);
            }
        }
        if (startposY == true)
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(CrushingSpeed * Vector2.up);
        }
        if (collision.gameObject.CompareTag("InvisibleWall"))
        {
            DowntimeBetweenAttacks = false;
            startposY = true;
            rb.velocity = Vector2.zero;
        }
    }
}

