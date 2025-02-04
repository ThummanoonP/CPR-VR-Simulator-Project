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
        #if UNITY_EDITOR
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        #else
        Application.Quit();
        #endif

    }
    public void TutorialMode()
    {
        SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
    }
    public void TitleMenu()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}

