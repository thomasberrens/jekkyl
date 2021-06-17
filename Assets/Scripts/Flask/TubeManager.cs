using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TubeManager : MonoBehaviour
    {
        private List<GameObject> TubesInRoom = new List<GameObject>();
        private EventManager _eventManager;
        
        [SerializeField] private int MaxResets;
        [SerializeField] private int CurrentResets;
        [SerializeField] private Text UIText;
        
        private void Start()
        {
            _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
            UIText.text = CurrentResets + "/" + MaxResets;
        }

        private void Update()
        {
            
        }


        public void AddTubeInRoom(GameObject gameObject)
        {
            TubesInRoom.Add(gameObject);
        }

        public void ResetAllTubesInRoom()
        {
            CurrentResets++;
            UIText.text = CurrentResets + "/" + MaxResets;
            if (CurrentResets > MaxResets)
            {
                _eventManager.OnRoomLose?.Invoke();
                return;
            }
            
            _eventManager.OnTubeReset?.Invoke();

            foreach (GameObject gameObject in TubesInRoom)
            {
                DragAndDrop tube = gameObject.GetComponent<DragAndDrop>();
                tube.ResetTube();
            }
        }
    }
