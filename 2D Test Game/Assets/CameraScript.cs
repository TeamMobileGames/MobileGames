using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraScript : MonoBehaviour {

    public Transform charakter;
    public Tilemap map;

    public float worldSizeX;
    public float worldSizeY;
    

    void LateUpdate () {
        

        if (charakter.position.x <= worldSizeX && charakter.position.x >= -worldSizeX)
        {
            transform.position = new Vector3(charakter.position.x, transform.position.y, transform.position.z);
        }
        if (charakter.position.y <= worldSizeY && charakter.position.y >= -worldSizeY)
        {
            transform.position = new Vector3(transform.position.x, charakter.position.y, transform.position.z);
        }
        if (charakter.position.y <= worldSizeY && charakter.position.y >= -worldSizeY && charakter.position.x <= worldSizeX && charakter.position.x >= -worldSizeX)
        {
            transform.position = new Vector3(charakter.position.x, charakter.position.y, transform.position.z);
        }
        
    }
}
