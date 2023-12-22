using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikefall : MonoBehaviour
{
    [SerializeField] private GameObject SH;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator ani;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grounds"))
        {
            ani.SetTrigger("unhit");
            rb.bodyType = RigidbodyType2D.Static;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetTrigger("hit");
        }
    }
}
