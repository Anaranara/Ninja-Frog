using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Transform respawn;
    public Animator animator;

    private void Update()
    {
        if(Life.checkpoint != new Vector2(respawn.position.x, respawn.position.y))
        {
            animator.SetBool("Saved", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 add = new Vector2(respawn.position.x, respawn.position.y);
            animator.SetBool("Saved", true);
            Life.checkpoint = add;
        }
    }
}
