using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnObject : ClickableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public override void OnMouseEnterLogic()
    {
        Debug.Log("Mouse is over GameObject: " + gameObject.name);
    }

    public override void OnMouseExitLogic()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject: " + gameObject.name);
    }

    public override void OnClickObjectLogic()
    {
        Debug.Log("Clicked!");
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
