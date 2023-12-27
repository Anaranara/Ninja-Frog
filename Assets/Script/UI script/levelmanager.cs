using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    public Animator Transis;
    public GameObject[] level;
    public TextMeshProUGUI t;

    // Start is called before the first frame update
    void Start()
    {
        level[Menu.currlvl].SetActive(true);
    }
    public void Next()
    {
        StartCoroutine(Loadscreen());     
    }
    IEnumerator Loadscreen()
    {
        if(Menu.currlvl >= 6)
        {
            Transis.SetTrigger("Endlvl");
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadScene("End");
        }
        Transis.SetTrigger("Endlvl");
        yield return new WaitForSeconds(1.2f);
        t.text = "Coins: 0";
        transform.position = Finish.Startpos;
        level[Menu.currlvl].SetActive(false);
        Menu.currlvl++;
        level[Menu.currlvl].SetActive(true);
        Transis.SetTrigger("Startlvl");
    }
}
