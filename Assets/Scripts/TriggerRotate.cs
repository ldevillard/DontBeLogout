using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotate : MonoBehaviour
{
    public int ID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopAllCoroutines();
            switch (ID)
            {
                case 0:
                    PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case 1:
                    PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, -90);
                    break;
                case 2:
                    PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case 3:
                    PlayerController.Mine.Player.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
            }
        }
    }
}
