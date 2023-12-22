using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class optionmenu : MonoBehaviour
{
    public AudioMixer aud;
    public void setvolume(float volume)
    {
        aud.SetFloat("Volume", volume);
    }
}
