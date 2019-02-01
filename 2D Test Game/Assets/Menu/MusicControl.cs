using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour {

    public Sprite VolumeOn, VolumeOff;
    public Sprite SoundOn, SoundOff;
    public Button vButton;
    public Button sButton;
    private Image vImage;
    private Image sImage;

    private bool isOnV = true;
    private bool isOnS = true;


    // Use this for initialization
    void Start () {
        vImage = vButton.GetComponent<Image>();
        sImage = sButton.GetComponent<Image>();


        //image = gameObject.GetComponent<Image>();
        //if Volume is not 50 it's false
        //SetVolume();
    }
	
	// Update is called once per frame
	void Update () {

        //SetVolume();



    }
    public void SetSound()
    {
        if (!isOnS)
        {
            //set the Sprite
            isOnS = true;

            sImage.sprite = SoundOn;

            //Sound gs= Array.Find(gm.sounds, sound => sound.name == "GameSound");
            // gs.volume = 0;
        }
        else
        {
            isOnS = false;
            sImage.sprite = SoundOff;

        }
    }

    public void SetVolume()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!isOnV)
        {
            //set the Sprite
            isOnV = true;

            vImage.sprite = VolumeOn;

            //Sound gs= Array.Find(gm.sounds, sound => sound.name == "GameSound");
           // gs.volume = 0;
        }
        else
        {
            isOnV = false;
            vImage.sprite = VolumeOff;

        }
    }
}
