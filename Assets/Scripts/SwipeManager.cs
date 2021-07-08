using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    void Update()
    {
        Swipe();
        GetKeys();
    }

    public void GetKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerController.Mine.direction = 3;
            GameManager.GameStarted = true;
           // PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerController.Mine.direction = 4;
            GameManager.GameStarted = true;
            // PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerController.Mine.direction = 1;
            GameManager.GameStarted = true;
            // PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerController.Mine.direction = 2;
            GameManager.GameStarted = true;
            // PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                GameManager.GameStarted = true;
                if (Distance.x < -swipeRange)
                {
                    //Debug.Log("Left");

                    PlayerController.Mine.direction = 3;
                    //PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 90);

                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    //Debug.Log("Right");
                    PlayerController.Mine.direction = 4;
                    //PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, -90);
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    //Debug.Log("Up");
                    
                    PlayerController.Mine.direction = 1;
                    //PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 0);
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                   // Debug.Log("Down");
                    
                    PlayerController.Mine.direction = 2;
                    //PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 180);
                    stopTouch = true;
                }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("Tap");
            }

        }


    }
}