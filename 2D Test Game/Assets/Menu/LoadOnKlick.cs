using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnKlick : MonoBehaviour {

    public GameObject loadingImage;
    public int scene;

    private void Update()
    {

    }

    public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(scene);
    }

}
