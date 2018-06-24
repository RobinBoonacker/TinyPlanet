using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void ChangeSceneButton(string gameLevel)
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void StopApplication()
    {
        Application.Quit();
    }
}
