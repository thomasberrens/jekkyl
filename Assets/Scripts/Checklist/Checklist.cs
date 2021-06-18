using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{
    
    private Dictionary<PickableObjects, GameObject> RoomObjects = new Dictionary<PickableObjects, GameObject>();
    
    private Dictionary<PickableObjects, GameObject> PickedUpItems = new Dictionary<PickableObjects, GameObject>();
    
    private EventManager EventManager;

    private Dictionary<PickableObjects, GameObject> ChecklistTexts = new Dictionary<PickableObjects, GameObject>();

    private Scene CurrentScene;
    
    public List<GameObject> textObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        EventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        CurrentScene = SceneManager.GetActiveScene();
        foreach (GameObject _gameObject in GameObject.FindGameObjectsWithTag("Checklist"))
        {
            PickableObjects type = ParseEnum<PickableObjects>(_gameObject.name);
            
            if (type == null) continue;
            
            RoomObjects.Add(type, _gameObject);
        }

        
        int i = 0;
        foreach (GameObject _textObject in textObjects)
        {
            Text text = _textObject.GetComponent<Text>();
            text.text = "";
            
            if (RoomObjects.Count <= i) continue;
            
            GameObject _gameObject = RoomObjects.ElementAt(i).Value;
            _textObject.name = _gameObject.name;
            
            PickableObjects type = ParseEnum<PickableObjects>(_textObject.name);
            text.text += _textObject.name;
            text.color = Color.red;
            
            ChecklistTexts.Add(type, _textObject);
            i++;
        }

        foreach (PickableObjects type in RoomObjects.Keys)
        {
            Debug.Log("Added: " + type);
        }
        
        
    }

    private void Start()
    {
        HandleSaveData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleSaveData()
    {
        if (DoesDataExists(CurrentScene.name + "_checklist_done"))
        {
            foreach (GameObject gameObject in ChecklistTexts.Values)
            {
                Text text = gameObject.GetComponent<Text>();
                text.color = Color.green;
                Debug.Log("Done");

            }

            foreach (GameObject gameObject in RoomObjects.Values)
            {
                gameObject.GetComponent<ClickableObject>().SetFound(true);
            }
        }
    }

    private void SaveData(string DataToSave)
    {
        SaveManager.WriteString(DataToSave);
    }

    private bool DoesDataExists(string DataToCheck)
    {
       return SaveManager.AllData.Contains(DataToCheck);
    }

    public void OnItemPickup(GameObject pickedUpObject)
    {
        if (pickedUpObject == null) return;
        if (!HasPlayerPickedUpItem(pickedUpObject))
        {
            AddItemToPickedUpList(pickedUpObject);
            PickableObjects type = ParseEnum<PickableObjects>(pickedUpObject.name);
            
            Debug.Log("Picked up: " + type);
            EventManager.OnItemPickup?.Invoke();

            GameObject checklistObject = ChecklistTexts[type];
            Text text = checklistObject.GetComponent<Text>();
            text.color = Color.green;

            if (HasPlayerPickedUpEverything())
            {
                SaveData(CurrentScene.name + "_checklist_done");
                EventManager.OnRoomWin?.Invoke();
            }
        }
        else
        {
            Debug.Log("Already picked up");
        }
    }

    public bool HasPlayerPickedUpEverything()
    {
        return RoomObjects.Count.Equals(PickedUpItems.Count);
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
