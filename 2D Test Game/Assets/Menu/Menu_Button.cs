using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Button : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject ScorePanel;

    // Use this for initialization
    void Start()
    {

        MenuPanel.SetActive(true);
        ScorePanel.SetActive(false);


    }


    void Update()
    {
    }


    public void ShowScorePanel()
    {
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
    }
    // Update is called once per frame 

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        ScorePanel.SetActive(false);

    }


}
