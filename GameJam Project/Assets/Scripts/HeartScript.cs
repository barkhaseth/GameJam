using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public float speedX = 3.0f;
    GameController gameController;
    Rigidbody2D rb;
    public float amountOfForceXKnockback = 10f;
    public float amountOfForceYKnockback = 0;
    public float VibrationAmountLimitNeg = -1;
    public float VibrationAmountLimitPos = 1.2f;
    public float VibrationAmount;
    bool BirdDeath = false;
    public float changeVibrationTimer = 0.2f;
    public CameraShake cameraShake;
    int count = 0;
    float InitialYPos;
    public float amplitude = 1.5f;
    public float frequency = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        InitialYPos = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        if (BirdDeath == false)
        {
            float newYPos = InitialYPos + Mathf.Sin(Time.time * frequency) * amplitude;
            rb.velocity = new Vector2(speedX, newYPos - transform.position.y);
        }
    }

    private IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pillar"))
        {
            BirdDeath = true;
            rb.velocity = new Vector2(0, -3);
            StartCoroutine(DestroyBomb());
            //rb.velocity = Vector2.zero;
            //rb.AddForce(amountOfForceYKnockback * Vector2.down, ForceMode2D.Impulse);
        }
        if (collision.CompareTag("Spikes"))
        {
            count++;
            if (count == 1)
            {
                gameController.increaseLives();
                gameController.HeartSound();
                Destroy(this.gameObject);
            }
        }
        if (collision.CompareTag("LifeLost"))
        {
            Destroy(this.gameObject);
        }

    }
}