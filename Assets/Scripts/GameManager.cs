using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool GameStarted;
    public GameObject[] Computers;
    static public bool CoroutLaunched;

    public float speedToAccess;
    public float speedIdle;
    public float timeToPass;

    static public bool Acceed;

    static public int i;
    static public int PlayerPos;

    static public string Password;
    static public string CorrectPass;

    void Start()
    {
        GameStarted = false;
        CoroutLaunched = false;
        Password = "";

        speedToAccess = 1.5f;
        timeToPass = 3f;
        speedIdle = 1f;
    }

    void FixedUpdate()
    {
        if (!CoroutLaunched && GameStarted)
        {
            CoroutLaunched = true;
            i = Random.Range(0, 4);
            while (i == PlayerPos)
                i = Random.Range(0, 4);
            Debug.Log(i);
            StartCoroutine(DelogComputer(Computers[i]));
        }
    }

    static public void FailGame()
    {
        Debug.Log("Fail");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelogComputer(GameObject computer)
    {
        Password = "";
        Acceed = false;
        computer.GetComponent<ComputerCollision>().SetBlackBars(true);
        yield return new WaitForSeconds(speedToAccess);
        if (!Acceed)
            FailGame();
        else
        {
            UIManager.Mine.ActivateKeyboard();
            yield return new WaitForSeconds(timeToPass);
            UIManager.Mine.DesactivateKeyboard();
            if (Password == CorrectPass)
            {
                Debug.Log("Win");
                computer.GetComponent<ComputerCollision>().SetBlackBars(false);
            }
            else
                FailGame();
            yield return new WaitForSeconds(speedToAccess);
        }
        CoroutLaunched = false;
    }
}
