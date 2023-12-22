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
        if (Input.GetKeyDown("w") && grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        aniupdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounds") || collision.gameObject.CompareTag("RH"))
        {
            if (grounded())
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
    private bool grounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpable);
    }
}
