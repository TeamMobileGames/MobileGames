using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public Sprite VolumeOn, VolumeOff;
    public SpriteRenderer spriteRenderer;
    
    
    // Use this for initialization

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //if Volume is not 50 it's false
        SetVolume(PlayerPrefs.GetInt("volume", 50) != 50 ? false : true);
    }

    // Update is called once per frame
    void Update()
    {

        if (isTouched())
        {
            //Set the Volume to 50 if it doesn't exist, if it's not equal 50 it's true
            SetVolume(PlayerPrefs.GetInt("volume", 50) != 50 ? true : false);
        }
    }

    private void SetVolume(bool isOn)
    {
        if (isOn)
        {
            spriteRenderer.sprite = VolumeOn;
            PlayerPrefs.GetInt("volume", 50);
        }
        else
        {
            spriteRenderer.sprite = VolumeOff;
            PlayerPrefs.GetInt("volume", 0);
        }
    }

    public bool isTouched()
    {
        bool status = false;
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                //Get the position of touch in the Screen 
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                //store these position in touchPosition
                Vector2 touchPosition = new Vector2(point.x, point.y);
                //Check if position of touch is overlapped with Collider
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                {

                    status = true;
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Get the position of touch in the Screen 
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //store these position in touchPosition
            Vector2 mousePosition = new Vector2(point.x, point.y);
            //Check if position of touch is overlapped with Collider
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
            {

                status = true;
            }
        }
        return status;
    }
}
