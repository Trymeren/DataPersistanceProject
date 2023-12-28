using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_Text inputText;

    public void StartGame()
    {
        SaveObject.Instance.LoadHighscore();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveUserNameOnSaveObject()
    {
        SaveObject.Instance.InputToText();
        Debug.Log("UserName supposedly saved");
    }

    public void TestUsername()
    {
        Debug.Log(SaveObject.Instance.userName);

        if(SaveObject.Instance == null)
        {
            Debug.Log("Instance is null");
        }
    }
}
