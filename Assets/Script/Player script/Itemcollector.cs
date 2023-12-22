using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Itemcollector : MonoBehaviour
{
    public static int coins;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource collect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            collect.Play();
            coins += 1;
            text.text = "Coins: " + coins;
        }
    }
}
