using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    public AudioSource dyingSound;
    public AudioSource pickUpSound;

    private void PlayDyingSound()
    {
        dyingSound.Play();
    }
    private void PlayPickUpSound()
    {
        pickUpSound.Play();
    }
}
