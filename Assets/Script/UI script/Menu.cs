using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour
{
    public levelobject[] lvlobject;
    public Sprite goldstar;
    public static int currlvl;
    public static int unlocklvl;

    [SerializeField] private float timetransis = 1.2f;
    public Animator Transis;
    public void Onclicklvl(int levelnum)
    {
        StartCoroutine(Levelbutton(levelnum,timetransis));
    }
    public void Start()
    {
        unlocklvl = PlayerPrefs.GetInt("unlocklvl",0);
        for(int i = 0; i < lvlobject.Length; i++)
        {
            if(unlocklvl >= i)
            {
                lvlobject[i].lvlbut.interactable = true;
                int star = PlayerPrefs.GetInt("star" + i.ToString(), 0);
                for(int j = 0; j < star; j++)
                {
                    lvlobject[i].star[j].sprite = goldstar;
                }
            }
        }
    }
    public void Quitbut()
    {
        Application.Quit();
    }
    IEnumerator Levelbutton(int level, float time)
    {
        Transis.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        currlvl = level;
        SceneManager.LoadScene("Gamescene");
    }
}
