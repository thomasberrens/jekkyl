using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : ClickableObject
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
        
    }

    public override void OnMouseExitLogic()
    {
        
    }

    public override void OnClickObjectLogic()
    {
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
