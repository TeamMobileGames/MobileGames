using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour {

    public GameObject UpgradePanel;
    public GameObject JoystickWalk;
    public GameObject JoystickShot;

    void Start()
    {
        UpgradePanel.SetActive(false);
    }



    public void ShowUpgradePanel()
    {
        UpgradePanel.SetActive(true);
        JoystickWalk.SetActive(false);
        JoystickShot.SetActive(false);
        Time.timeScale = 0;
    }

    public void resumeGame()
    {
        UpgradePanel.SetActive(false);
        JoystickWalk.SetActive(true);
        JoystickShot.SetActive(true);
        Time.timeScale = 1;
    }

    public void LifePointsButtonPressed()
    {
        EventManager.TriggerEvent("LifePointsButtonPressed");
    }

    public void DamageButtonPressed()
    {
        EventManager.TriggerEvent("DamageButtonPressed");
    }



}

