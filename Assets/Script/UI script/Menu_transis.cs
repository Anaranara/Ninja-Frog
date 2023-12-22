using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_transis : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject Chooselevelmenu;
    public GameObject Howmenu;
    public GameObject Optionmenu;
    public Animator trans;

    [SerializeField] float dur = 1.2f;

    public void chooselevel()
    {
        StartCoroutine(Chooseleveltransis(dur));
    }
    public void How()
    {
        StartCoroutine(Howtransis(dur));
    }
    public void Option()
    {
        StartCoroutine(Optiontransis(dur));
    }
    public void HowBack()
    {
        StartCoroutine(HowBacktransis(dur));
    }
    public void ChooselvlBack()
    {
        StartCoroutine(ChooselvlBacktransis(dur));
    }
    public void OptionBack()
    {
        StartCoroutine(OptionBacktransis(dur));
    }
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
    IEnumerator Chooseleveltransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Mainmenu.SetActive(false);
        Chooselevelmenu.SetActive(true);
        trans.SetTrigger("End");
    }
    IEnumerator Howtransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Mainmenu.SetActive(false);
        Howmenu.SetActive(true);
        trans.SetTrigger("End");
    }
    IEnumerator Optiontransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Mainmenu.SetActive(false);
        Optionmenu.SetActive(true);
        trans.SetTrigger("End");
    }
    IEnumerator OptionBacktransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Optionmenu.SetActive(false);
        Mainmenu.SetActive(true);
        trans.SetTrigger("End");
    }
    IEnumerator HowBacktransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Howmenu.SetActive(false);
        Mainmenu.SetActive(true);
        trans.SetTrigger("End");
    }
    IEnumerator ChooselvlBacktransis(float time)
    {
        trans.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        Chooselevelmenu.SetActive(false);
        Mainmenu.SetActive(true);
        trans.SetTrigger("End");
    }
}
