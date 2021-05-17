using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (!checklist.HasPlayerPickedUpItem(gameObject))
        {
            checklist.AddItemToPickedUpList(this.gameObject);
            EventManager.OnItemPickup?.Invoke();
            Debug.Log("Picked up: " + checklist.ParseEnum<PickableObjects>(gameObject.name));
        }
        else
        {
            Debug.Log("Already picked up");
        }
        
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
