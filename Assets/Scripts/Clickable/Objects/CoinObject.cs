using System.Security.Cryptography;
using UnityEngine;

public class CoinObject : ClickableObject
{
    private GameObject RoomManager;

    private EventManager EventManager;
    
    void Start()
    {
        RoomManager = GameObject.Find("RoomManager");
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
        checklist.OnItemPickup(gameObject);
    }

    public override bool CanClickObject()
    {
        return true;
    }
}