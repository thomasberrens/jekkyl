using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenVase : ClickableObject
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
        GameObject.FindWithTag("EventManager").GetComponent<EventManager>().OnShowTicket?.Invoke();
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
