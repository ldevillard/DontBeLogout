using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCollision : MonoBehaviour
{
    static public ComputerCollision Mine;

    public int ID;

    public GameObject[] BlackBar;

    void Start()
    {
        Mine = this;
        SetBlackBars(false);
    }

    public void SetBlackBars(bool status)
    {
        BlackBar[0].gameObject.SetActive(status);
        BlackBar[1].gameObject.SetActive(status);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ID == GameManager.i && GameManager.CoroutLaunched)
            GameManager.Acceed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && ID == GameManager.i && GameManager.CoroutLaunched)
            GameManager.Acceed = true;
        GameManager.PlayerPos = ID;
    }
}
