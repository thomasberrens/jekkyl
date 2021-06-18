using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : ClickableObject
{

    [SerializeField] private string SceneToSwitch;
    private EventManager _eventManager;
    private LevelLoader _levelLoader;
    private void Start()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _levelLoader = FindObjectOfType<LevelLoader>();
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
        _levelLoader.LoadLevelAnimation(SceneToSwitch);
    }
    

    public override bool CanClickObject()
    {
        return true;
    }
}
