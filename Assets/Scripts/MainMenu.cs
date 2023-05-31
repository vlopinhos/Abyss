using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void ExitGame()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}
