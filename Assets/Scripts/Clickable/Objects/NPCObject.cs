using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : ClickableObject
{

  //  private GameObject DialogueNPC;

    private DialogueTrigger _dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
     //   DialogueNPC = GameObject.FindWithTag("DialogueNPC");
        _dialogueTrigger = GetComponent<DialogueTrigger>();
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
        _dialogueTrigger.TriggerDialogue();
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
