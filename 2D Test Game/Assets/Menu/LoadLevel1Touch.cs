﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel1Touch : MonoBehaviour {

    public GameObject loadingImage;

	// Update is called once per frame
	public void loadOnTouch(int level) {
        //        Touch myTouch = Input.GetTouch(0);

        //      Touch[] myTouches = Input.touches;
        //    for (int i = 0; i < Input.touchCount; i++)
        //  {

       // if (Input.GetTouch(0).phase == TouchPhase.Began) {
         //   if (Input.GetTouch(0).phase == TouchPhase.Ended) {
                //Do something with the touches
                loadingImage.SetActive(true);
                SceneManager.LoadScene(level);
           // }
       // }
    }
}