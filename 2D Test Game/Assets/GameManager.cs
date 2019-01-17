﻿using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int coin = 0;
    public Sound[] sounds;
    public Text CoinAmmount;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }

    }

    private void Start()
    {
        Play("GameSound");
    }
    
    void OnEnable()
    {
        EventManager.StartListening("CoinPicked", CoinPicked);
        EventManager.StartListening("FlamethrowerShoot", FlamethrowerShootSound);
    }

    void OnDisable()
    {
        EventManager.StopListening("CoinPicked", CoinPicked);
        EventManager.StopListening("FlamethrowerShoot", FlamethrowerShootSound);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void FlamethrowerShootSound()
    {
        Play("FlamethrowerShoot");
    }

    void CoinPicked()
    {
        coin++;
        CoinAmmount.text = "" + coin;
        Play("CoinSound");
    }
}
