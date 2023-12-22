using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private Animator Transis;
    public void Tomenu()
    {
        StartCoroutine(tomainMenu());
    }
    public void endgame()
    {
        Application.Quit();
    }
    IEnumerator tomainMenu()
    {
        Transis.SetTrigger("To menu");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Start_menu");
    }
}
