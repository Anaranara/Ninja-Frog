using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finish;
    private bool complete = false;
    [SerializeField] Image star_on;
    [SerializeField] Image star_off;
    [SerializeField] private GameObject endpanel;
    public static Vector2 Startpos;

    void Start()
    { 
        Startpos = transform.position;
        finish = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player" && !complete)
        {
            finish.Play();
            complete = true;
            if (GameObject.FindGameObjectsWithTag("Coins").Length <= 0)
            {
                Itemcollector.coins = 0;
                StartCoroutine(Completelvl(1));
            }
            else
            {
                Itemcollector.coins = 0;
                StartCoroutine(Completelvl(0));
            }
        }
    }
    IEnumerator Completelvl(int star)
    {
        yield return new WaitForSeconds(0.2f);
        Playermovement.rb.simulated = false;
        yield return new WaitForSeconds(1.2f);
        if (Menu.currlvl == Menu.unlocklvl)
        {
            Menu.unlocklvl++;
            PlayerPrefs.SetInt("unlocklvl", Menu.unlocklvl);
        }
        if (star > PlayerPrefs.GetInt("star" + Menu.currlvl.ToString(), 0))
        {
            PlayerPrefs.SetInt("star" + Menu.currlvl.ToString(), star);
        }
        if (star > 0)
        {
            endpanel.SetActive(true);
            star_on.enabled = true;
            star_off.enabled = false;
        }
        else
        {
            endpanel.SetActive(true);
            star_on.enabled = false;
            star_off.enabled = true;
        }
    }
}
