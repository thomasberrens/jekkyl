using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayWithData()
    {
        Destroy(GameObject.FindWithTag("BackgroundMusic"));
        SceneManager.LoadScene(0);
    }

    public void ReplayWithoutData()
    {
        SaveManager.AllData.Clear();
        File.Delete(SaveManager.GetPath());
        Destroy(GameObject.FindWithTag("BackgroundMusic"));
        SceneManager.LoadScene(0);
    }
}
