using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : ClickableObject
{

    [SerializeField] private string SceneToSwitch;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public override void OnMouseEnterLogic()
    {
       
    }

    public override void OnMouseExitLogic()
    {
    
    }

    public override void OnClickObjectLogic()
    {
        SceneManager.LoadScene(SceneToSwitch);
    }
    

    public override bool CanClickObject()
    {
        return true;
    }
}
