using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource deadsound;

    public static Vector2 checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = transform.position;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    public void updatecheckpoint(Vector2 pos) 
    {
        checkpoint = pos;
    }
    private void Die()
    {
        deadsound.Play();
        rb.simulated = false;
        ani.SetTrigger("Dead");
        StartCoroutine(Respawn(1.5f));
    }
    IEnumerator Respawn(float dur)
    {
        yield return new WaitForSeconds(dur);
        ani.SetTrigger("Respawn");
        transform.position = checkpoint;
        rb.simulated = true;
    }
}
