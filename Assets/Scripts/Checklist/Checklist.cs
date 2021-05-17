using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Checklist : MonoBehaviour
{
    
    private Dictionary<PickableObjects, GameObject> RoomObjects = new Dictionary<PickableObjects, GameObject>();
    
    private Dictionary<PickableObjects, GameObject> PickedUpItems = new Dictionary<PickableObjects, GameObject>();
    
    private EventManager EventManager;
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager = GetComponent<EventManager>();
        foreach (GameObject _gameObject in GameObject.FindGameObjectsWithTag("Checklist"))
        {
            PickableObjects type = ParseEnum<PickableObjects>(_gameObject.name);
            if (type == null) continue;
            
            RoomObjects.Add(type, _gameObject);
        }


        foreach (PickableObjects type in RoomObjects.Keys)
        {
            Debug.Log("Added: " + type);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasPlayerPickedUpEverything())
        {
            Debug.Log("WIN");
            EventManager.OnRoomWin?.Invoke();
        }
    }

    public void OnItemPickup(GameObject pickedUpObject)
    {
        if (pickedUpObject == null) return;
        if (!HasPlayerPickedUpItem(pickedUpObject))
        {
            AddItemToPickedUpList(pickedUpObject);
            Debug.Log("Picked up: " + ParseEnum<PickableObjects>(pickedUpObject.name));
        }
        else
        {
            Debug.Log("Already picked up");
        }
    }

    public bool HasPlayerPickedUpEverything()
    {

        return RoomObjects.Count == PickedUpItems.Count;
    }

    public Dictionary<PickableObjects, GameObject> GetAllRoomObjects()
    {
        return RoomObjects;
    }
    
    public Dictionary<PickableObjects, GameObject> GetPickedUpItems()
    {
        return PickedUpItems;
    }

    public void AddItemToPickedUpList(GameObject gameObject)
    {
        PickableObjects type = ParseEnum<PickableObjects>(gameObject.name);
        PickedUpItems.Add(type, gameObject);
    }

    public bool HasPlayerPickedUpItem(GameObject gameObject)
    {
        PickableObjects type = ParseEnum<PickableObjects>(gameObject.name);
        return PickedUpItems.ContainsKey(type);
    }

    public T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}
