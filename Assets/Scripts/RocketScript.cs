using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{

    public Text countText;
    public string gameLevel;
    public string myString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;

    private void OnMouseDown()
    {
        int count = int.Parse(countText.text);
        if (count >= 5000)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(gameLevel);
        }

    }

    void Start()
    {
        myText.color = Color.clear;

    }

    void Update()
    {
        FadeText();
    }

    void OnMouseOver()
    {
        displayInfo = true;
    }



    void OnMouseExit()

    {
        displayInfo = false;
    }


    void FadeText()
    {
        if (displayInfo)
        {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }

        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }

}
