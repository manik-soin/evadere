using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class VOLUME_SCRIPT : MonoBehaviour
{
    public AudioSource AudioSource1;
    public static readonly string global_vol = "global_vol";

    private float Globalvol = 1f;

    // Update is called once per frame
    void Update()
    {
        AudioSource1.volume = Globalvol;
        
    }

    public void updateVol(float volume)
    {
        Globalvol = volume;
        AudioSource1.volume = volume;
        PlayerPrefs.SetFloat(global_vol, Globalvol);
        
    }
}
