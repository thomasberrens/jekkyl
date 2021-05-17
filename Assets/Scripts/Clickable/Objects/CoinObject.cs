using UnityEngine;

public class CoinObject : ClickableObject
{
    private GameObject RoomManager;

    private EventManager EventManager;
    
    void Start()
    {
        RoomManager = GameObject.Find("RoomManager");
        EventManager = RoomManager.GetComponent<EventManager>();
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
            Debug.Log("Picked up: " + checklist.ParseEnum<ChecklistType>(gameObject.name));
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