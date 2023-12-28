using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveObject : MonoBehaviour
{
    public static SaveObject Instance;
    private TMP_Text nameInput;
    public string userName;

    public string curHighName = "name";
    public int curHighscore = 0;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
    
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public void InputToText()
    {
        nameInput = GameObject.Find("UserNameText").GetComponent<TMP_Text>();
        if(nameInput.text.ToString() != "​")
        {
        SaveObject.Instance.userName = nameInput.text.ToString();
        Debug.Log("Name Set To :" + SaveObject.Instance.userName);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string curHighName;
        public int curHighscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.curHighscore = curHighscore;
        data.curHighName = curHighName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            curHighName = data.curHighName;
            curHighscore = data.curHighscore;
        }
    }
}
