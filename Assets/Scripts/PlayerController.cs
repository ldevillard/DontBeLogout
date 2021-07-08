using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController Mine;

    public float speed;
    public int direction;

    bool topLeft, topRight, bottomLeft, bottomRight;
    bool isRotating;

    public GameObject Player;

    void Start()
    {
        Mine = this;
        speed = 10;
        direction = 0;

        ResetPositionBool();
        RandomPosition();
    }

    void ResetPositionBool()
    {
        topLeft = false;
        topRight = false;
        bottomLeft = false;
        bottomRight = false;
    }

    void RandomPosition()
    {
        int i = Random.Range(0, 4);

        switch (i)
        {
            case 0:
                transform.position = new Vector3(0.06f, -0.85f, transform.position.z); //BOTTOM LEFT
                Player.transform.eulerAngles = new Vector3(0, 0, 180);
                bottomLeft = true;
                break;
            case 1:
                transform.position = new Vector3(0.4f, -0.85f, transform.position.z); //BOTTOM RIGHT
                Player.transform.eulerAngles = new Vector3(0, 0, -90);
                bottomRight = true;
                break;
            case 2:
                transform.position = new Vector3(0.06f, 0.3f, transform.position.z); //TOP LEFT
                Player.transform.eulerAngles = new Vector3(0, 0, 90);
                topLeft = true;
                break;
            case 3:
                transform.position = new Vector3(0.4f, 0.3f, transform.position.z); //TOP RIGHT
                Player.transform.eulerAngles = new Vector3(0, 0, 0);
                topRight = true;
                break;
        }
    }

    void Update()
    {
        if (direction == 1) //UP
        {
            if (transform.position.y < 0.3f)
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, 0.3f, speed * Time.deltaTime), transform.position.z);
        }
        else if (direction == 2) //DOWN
        {
            if (transform.position.y > -0.85f)
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, -0.85f, speed * Time.deltaTime), transform.position.z);
        }
        else if (direction == 3) //LEFT
        {
            if (transform.position.x > 0.06f)
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0.06f, speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        else if (direction == 4)
        {
            if (transform.position.x < 0.4f) //RIGHT
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0.4f, speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }

}
