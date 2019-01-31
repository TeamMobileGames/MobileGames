using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Button : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject ScorePanel;
    public GameObject OptionPanel;

    // Use this for initialization
    void Start()
    {

        MenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
        OptionPanel.SetActive(false);


    }


    void Update()
    {
    }

    public void ShowOptionPanel()
    {
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(false);
        OptionPanel.SetActive(true);

    }
    public void ShowScorePanel()
    {
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
    // Update is called once per frame 

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
        OptionPanel.SetActive(false);

    }


}
