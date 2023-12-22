using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rockhead: MonoBehaviour
{
    [SerializeField] private GameObject RH;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator ani;
    // Start is called before the first frame update
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
            RH.tag = "RH";
            rb.bodyType= RigidbodyType2D.Static;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetTrigger("hit");
        }
    }
}
