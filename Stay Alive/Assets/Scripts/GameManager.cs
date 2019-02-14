using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int coin = 0;
    private int score = 0;
    public int upgradePrice;
    public Sound[] sounds;
    public Text coinText;
    public Text scoreText;

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
        EventManager.StartListening("SlimeDied", SlimeDied);
        EventManager.StartListening("GameOver", GameOver);
        EventManager.StartListening("DamageButtonPressed", DamageButtonPressed);
        EventManager.StartListening("LifePointsButtonPressed", LifePointsButtonPressed);
    }

    void OnDisable()
    {
        EventManager.StopListening("CoinPicked", CoinPicked);
        EventManager.StopListening("FlamethrowerShoot", FlamethrowerShootSound);
        EventManager.StopListening("SlimeDied", SlimeDied);
        EventManager.StopListening("GameOver", GameOver);
        EventManager.StopListening("DamageButtonPressed", DamageButtonPressed);
        EventManager.StopListening("LifePointsButtonPressed", LifePointsButtonPressed);
    }

    public void DamageButtonPressed()
    {
        if(coin >= upgradePrice)
        {
            coin -= upgradePrice;
            EventManager.TriggerEvent("UpgradeDamage");
            coinText.text = "" + coin;
        }
    }
    public void LifePointsButtonPressed()
    {
        if (coin >= upgradePrice)
        {
            coin -= upgradePrice;
            EventManager.TriggerEvent("UpgradeLifePoints");
            coinText.text = "" + coin;
        }
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
        coinText.text = "" + coin;
        Play("CoinSound");
    }

    void SlimeDied()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        SceneManager.LoadScene("Menu");
    }
}
