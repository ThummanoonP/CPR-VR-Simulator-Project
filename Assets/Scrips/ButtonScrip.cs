using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ButtonScrip : MonoBehaviour
{
    public void StartProgram()
    {
        SceneManager.LoadScene("CPRScene", LoadSceneMode.Single);
    }

    public void QuitProgram()
    {
        if (EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        Application.Quit();

    }

    public void TitleMenu()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}

