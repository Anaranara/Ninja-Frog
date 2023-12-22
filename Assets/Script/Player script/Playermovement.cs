using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public static Rigidbody2D rb;
    private SpriteRenderer sp;
    private Collider2D coll;
    private Animator ani;

    [SerializeField] private LayerMask jumpable;
    public ParticleSystem Dust;

    private float x = 0f;

    [SerializeField] private float jumpforce = 14f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private AudioSource jumpsound;
    private enum movestate {idle,run,jump,fall};
    movestate st;
    private bool grounds = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        }
        if (Input.GetKeyDown("w") && grounds)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        aniupdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounds") || collision.gameObject.CompareTag("RH"))
        {
            if (grounds)
            {
                Dust.Play();
            }
        }
    }
    private void aniupdate()
    {
        if(x > 0f)
        {
            st = movestate.run;
            sp.flipX = false;
        }
        else if (x < 0f)
        {
            st = movestate.run;
            sp.flipX = true;
        }
        else
        {
            st = movestate.idle;
        }
        if (rb.velocity.y > .1f)
        {
            st = movestate.jump;
        }
        if(rb.velocity.y < -.1f)
        {
            st = movestate.fall;
        }
        ani.SetInteger("state", (int)st);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            grounds = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            grounds = false;
        }
    }
}
