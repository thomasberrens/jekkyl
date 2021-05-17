using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyObject : ClickableObject
{
    private GameObject RoomManager;

    private EventManager EventManager;
    // Start is called before the first frame update
    void Start()
    {
        RoomManager = GameObject.Find("RoomManager");
        EventManager = RoomManager.GetComponent<EventManager>();
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
        Checklist checklist = RoomManager.GetComponent<Checklist>();
        EventManager.OnItemPickup?.Invoke();
        checklist.OnItemPickup(gameObject);
        
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
