using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnKlick : MonoBehaviour {

    public GameObject loadingImage;
   //public int scene;

    private void Update()
    {

    }

    public void LoadScene()
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(1);
        Debug.Log("Level Load");
    }

}
