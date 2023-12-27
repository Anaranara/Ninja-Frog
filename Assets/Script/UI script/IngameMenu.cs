using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IngameMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pause;
    public GameObject pausebutton;
    public Animator Trans;
    [SerializeField] private TextMeshProUGUI T;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                pausebutton.SetActive(true);
                Resume();
            }
            else
            {
                pausebutton.SetActive(false);
                Paused();
            }
        }
    }
    public void Paused()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pauseloadmenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(Transistomenu());
    }
    public void Retrypause()
    {
        Time.timeScale = 1f;
        StartCoroutine(TransisRetry());
    }
    public void Retry()
    {
        StartCoroutine(TransisRetry());
    }
    public void gotomenu()
    {
        StartCoroutine(Transistomenu());
    }
    IEnumerator Transistomenu()
    {
        Trans.SetTrigger("Endlvl");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Start_Menu");
    }
    IEnumerator TransisRetry()
    {
        Trans.SetTrigger("Endlvl");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Itemcollector.coins = 0;
        T.text = "Coins: 0";
    }
}
