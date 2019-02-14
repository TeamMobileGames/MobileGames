using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchtTest : MonoBehaviour {
    public InputField nameInput;
    public Toggle awesomeToggle;

    public void OnClickMyButton()
    {
        string name = nameInput.text;
        bool isAwesome = awesomeToggle.isOn;
    }
    // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

       /* if (Input.GetTouch(0).phase == TouchPhase.Began){
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

            }

}           
            */


    }
}
