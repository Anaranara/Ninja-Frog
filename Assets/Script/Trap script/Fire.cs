using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float delayBeforeActivation = 2f; 
    public float activeTime = 5.0f; 
    public float delayBeforeDeactivation = 2.0f; 

    public Animator animator; 

    private BoxCollider2D boxCollider; 

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(ToggleColliderAndAnimation());
    }

    IEnumerator ToggleColliderAndAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBeforeActivation);

            if (boxCollider != null)
            {
                boxCollider.enabled = true;
            }


            if (animator != null)
            {
                animator.SetBool("on", true);
            }

            yield return new WaitForSeconds(activeTime);

            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }


            if (animator != null)
            {
                animator.SetBool("on", false);
            }

            yield return new WaitForSeconds(delayBeforeDeactivation);
        }
    }
}
