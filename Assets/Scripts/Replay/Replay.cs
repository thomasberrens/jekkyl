using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : ClickableObject
{
    // Start is called before the first frame update
    [SerializeField] private bool WithSavedata;
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
        Debug.Log(GameObject.FindWithTag("BackgroundMusic"));
        Destroy(GameObject.FindWithTag("BackgroundMusic"));
        SceneManager.LoadScene(0);
    }

    public override void OnMouseEnterLogic()
    {
    }

    public override void OnMouseExitLogic()
    {
    }

    public override void OnClickObjectLogic()
    {
        if (WithSavedata)
        {
            ReplayWithData();
        }
        else
        {
            ReplayWithoutData();
        }
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
