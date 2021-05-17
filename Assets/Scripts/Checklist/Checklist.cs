using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    
    private Dictionary<ChecklistType, GameObject> _objects = new Dictionary<ChecklistType, GameObject>();
    
    private Dictionary<ChecklistType, GameObject> pickedUp = new Dictionary<ChecklistType, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject _gameObject in GameObject.FindGameObjectsWithTag("Checklist"))
        {
            ChecklistType type = ParseEnum<ChecklistType>(_gameObject.name);
            if (type == null) continue;
            
            _objects.Add(type, _gameObject);
        }


        foreach (ChecklistType type in _objects.Keys)
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
        }
    }

    public bool HasPlayerPickedUpEverything()
    {

        return _objects.Count == pickedUp.Count;
    }

    public Dictionary<ChecklistType, GameObject> GetAllItemsToPickup()
    {
        return _objects;
    }
    
    public Dictionary<ChecklistType, GameObject> GetPickedUpItems()
    {
        return pickedUp;
    }

    public void AddItemToPickedUpList(GameObject gameObject)
    {
        ChecklistType type = ParseEnum<ChecklistType>(gameObject.name);
        pickedUp.Add(type, gameObject);
    }

    public bool HasPlayerPickedUpItem(GameObject gameObject)
    {
        ChecklistType type = ParseEnum<ChecklistType>(gameObject.name);
        return pickedUp.ContainsKey(type);
    }

    public T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
}
