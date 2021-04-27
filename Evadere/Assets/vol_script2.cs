using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class vol_script2 : MonoBehaviour
{
    public AudioSource AudioSource;
    public static readonly string global_vol = "global_vol";

    private float Globalvol = 50;

    void Awake()
    {
        Globalvol = PlayerPrefs.GetFloat(global_vol);
        setVol();
    }
    // Update is called once per frame
    void setVol()
    {
        AudioSource.volume = Globalvol;
    }
}
