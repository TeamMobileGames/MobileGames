using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class FixedJoystick : Joystick
{
    public int joystickArea;
    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();
    private Vector2 joystickAreaSize;

    void Start()
    {
        if(joystickArea == 1)
        {
            joystickAreaSize = new Vector2(0,Screen.width/2);
        }
        else
        {
            joystickAreaSize = new Vector2(Screen.width / 2, Screen.width);
        }
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("touchCount  : " + Input.touchCount);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x >= joystickAreaSize.x && touch.position.x <= joystickAreaSize.y)
                {
                    this.transform.position = new Vector3(touch.position.x, touch.position.y, 0);
                    Input.GetMouseButtonDown(0);
                }
            }


        }
        else if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);
            Debug.Log("touchCount  : " + Input.touchCount);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x >= joystickAreaSize.x && touch.position.x <= joystickAreaSize.y)
                {
                    this.transform.position = new Vector3(touch.position.x, touch.position.y, 0);
                }
            }
        }
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        ClampJoystick();
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}