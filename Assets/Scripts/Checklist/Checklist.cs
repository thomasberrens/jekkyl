using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    
    private Dictionary<PickableObjects, GameObject> _objectsToPickUp = new Dictionary<PickableObjects, GameObject>();
    
    private Dictionary<PickableObjects, GameObject> pickedUp = new Dictionary<PickableObjects, GameObject>();
    
    private EventManager EventManager;
    // Start is called before the first frame update
    void Start()
    {
        EventManager = GetComponent<EventManager>();
        foreach (GameObject _gameObject in GameObject.FindGameObjectsWithTag("Checklist"))
        {
            PickableObjects type = ParseEnum<PickableObjects>(_gameObject.name);
            if (type == null) continue;
            
            _objectsToPickUp.Add(type, _gameObject);
        }


        foreach (PickableObjects type in _objectsToPickUp.Keys)
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

    public bool HasPlayerPickedUpEverything()
    {

        return _objectsToPickUp.Count == pickedUp.Count;
    }

    public Dictionary<PickableObjects, GameObject> GetAllItemsToPickup()
    {
        return _objectsToPickUp;
    }
    
    public Dictionary<PickableObjects, GameObject> GetPickedUpItems()
    {
        return pickedUp;
    }

    public void AddItemToPickedUpList(GameObject gameObject)
    {
        PickableObjects type = ParseEnum<PickableObjects>(gameObject.name);
        pickedUp.Add(type, gameObject);
    }

    public bool HasPlayerPickedUpItem(GameObject gameObject)
    {
        PickableObjects type = ParseEnum<PickableObjects>(gameObject.name);
        return pickedUp.ContainsKey(type);
    }

    public T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}
