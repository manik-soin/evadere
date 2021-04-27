using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class vol_script3 : MonoBehaviour
{
    public AudioSource AudioSource = null;
    public static readonly string global_vol = "global_vol";

    private float Globalvol = 0;

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
