using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBirdScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float amountOfForceX = 1f;
    public float amountOfForceY = 20f;
    public float amountOfForceXKnockback = 1f;
    public float amountOfForceYKnockback = 0;
    bool FirstJump = true;
    public float LowerJumpDelay = 1f;
    public float UpperJumpDelay = 1f;
    bool canBirdMove = true;
    public float StunnedTime = 1f;
    public float despawnAfterDeath = 15f;
    bool BirdDeath = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(CallBirdJumpLogicRandomly());
    }
    private IEnumerator CallBirdJumpLogicRandomly()
    {
        float timer;
        while (BirdDeath == false)
        {
            timer = Random.Range(LowerJumpDelay, UpperJumpDelay);
            if (FirstJump)
            {
                FirstJump = false;
                BirdJumpLogic();
            }
            else
            {
                yield return new WaitForSeconds(timer);
                BirdJumpLogic();
            }
        }
    }
    private void BirdJumpLogic()
    {
        if (BirdDeath == false)
        {
            if (canBirdMove)
            {
                rb.gravityScale = 1;
                rb.AddForce(amountOfForceX * Vector2.right, ForceMode2D.Impulse);
                if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(amountOfForceY * Vector2.up, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(amountOfForceY * Vector2.up, ForceMode2D.Impulse);
                }
            }
            else
            {
                rb.gravityScale = 0;
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
                animator.Play("Green Bird Hit");
                StartCoroutine(DespawnBird());
                rb.velocity = Vector2.zero;
                StunnedTime = 60f;
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
        if (BirdDeath == false)
        {
            canBirdMove = false;
            yield return new WaitForSeconds(StunnedTime);
            rb.velocity = Vector2.zero;
            canBirdMove = true;
        }
    }
}

