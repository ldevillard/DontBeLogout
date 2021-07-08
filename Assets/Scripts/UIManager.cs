using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public UIManager Mine;

    public Animator anim;
    public InputField Password;

    void Start()
    {
        Mine = this;
        Password.gameObject.SetActive(false);
        anim.SetBool("GameStarted", false);
    }

    void Update()
    {
        if (GameManager.GameStarted)
            anim.SetBool("GameStarted", true);

        if (Password.IsActive())
        {
            //Debug.Log(Password.text);
            
            GameManager.Password = Password.text;
        }
    }

    public void ActivateKeyboard()
    {
        Password.gameObject.SetActive(true);
        Password.text = "";
        Password.ActivateInputField();
        GameManager.CorrectPass = GenerateWord();
        Password.placeholder.GetComponent<Text>().text = GameManager.CorrectPass;
    }

    public void DesactivateKeyboard()
    {
        Password.DeactivateInputField();
        Password.gameObject.SetActive(false);
    }

    public string GenerateWord() //Add arg for the lenght
    {
        string[] words = {"hello",
                "good",
                "well",
                "boy",
                "girl",
                "tree",
                "book",
                "place",
                "fire",
                "bin"};
        int i = Random.Range(0, words.Length);
        return words[i];
    }

}
