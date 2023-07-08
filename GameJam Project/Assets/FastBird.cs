using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBird : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speedX = 3f;
    public float VibrationAmountLimitNeg = -1;
    public float VibrationAmountLimitPos = 1.2f;
    public float VibrationAmount;
    public float changeVibrationTimer = 0.2f;
    public float StunnedTime = 1f;
    bool canBirdMove = true;
    public float amountOfForceXKnockback = 10f;
    public float amountOfForceYKnockback = 0;
    bool BirdDeath = false;
    public float despawnAfterDeath = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(VibrationGenerator());
    }
    private IEnumerator VibrationGenerator()
    {
        while (BirdDeath == false)
        {

            yield return new WaitForSeconds(changeVibrationTimer);
            VibrationAmount = Random.Range(VibrationAmountLimitNeg, VibrationAmountLimitPos);
            if (transform.position.y >= 4)
            {
                VibrationAmount = -Mathf.Abs(VibrationAmount);
            }
            if (transform.position.y <= -4)
            {
                VibrationAmount = Mathf.Abs(VibrationAmount);
            }

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (BirdDeath == false)
        {
            if (canBirdMove)
            {
                rb.velocity = new Vector2(speedX, VibrationAmount);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BirdDeath == false)
        {
            if (collision.CompareTag("Pillar"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(amountOfForceXKnockback * Vector2.left, ForceMode2D.Impulse);
                if (transform.position.y < 0)
                {
                    rb.AddForce(amountOfForceYKnockback * Vector2.up, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(amountOfForceYKnockback * Vector2.down, ForceMode2D.Impulse);
                }
                StartCoroutine(StunBird());
            }
            if (collision.CompareTag("Spikes"))
            {
                StartCoroutine(DespawnBird());
                rb.velocity = Vector2.zero;
                StunnedTime = 60f;
                animator.Play("Punk Bird Death");
                BirdDeath = true;
                rb.gravityScale = 1.0f;
            }
        }
    }
    private IEnumerator DespawnBird()
    {
        yield return new WaitForSeconds(despawnAfterDeath);
        Destroy(gameObject);
    }
    private IEnumerator StunBird()
    {
        if(BirdDeath==false)
        {
            canBirdMove = false;
            yield return new WaitForSeconds(StunnedTime);
            rb.velocity = Vector2.zero;
            canBirdMove = true;
        }
    }

}
