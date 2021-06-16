using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    private static string path = "Assets/Resources/savedata.txt";

    public static List<string> AllData;

    private Scene CurrentScene;

    private EventManager _eventManager;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        
        AllData = File.ReadAllLines(path).ToList();
    }

    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        if (AllData.Contains(CurrentScene.name + "_finished"))
        {
            _eventManager.OnRoomWin?.Invoke();
        }
        
        _eventManager.OnRoomWin?.AddListener(SaveSceneFinished);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSceneFinished()
    {
        WriteString(CurrentScene.name + "_finished");
    }

    public static void WriteString(string data)
    {
        //Write some text to the test.txt file
        if (AllData.Contains(data))
        {
            Debug.Log("Data already exists: " + data); 
            return;
        }
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(data);
        writer.Close();
    }

    [MenuItem("Tools/Read file")]
    public static string ReadString()
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();
        return text;
    }

}
