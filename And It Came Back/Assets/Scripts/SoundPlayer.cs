using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource westernGun;
    public AudioSource glassBreak;
    public AudioSource leverAction;

    public void playWesternGun()
    {
        westernGun.Play();
    }

    public void playGlassBreak()
    {
        glassBreak.Play();
    }
     public void playLeverAction()
    {
        leverAction.Play();
    }

    void Update()//plays westernGun when the player shoots
    {
        if (Input.GetButtonDown("Fire1"))
        {
            westernGun.Play();
        }
    }

    



}
