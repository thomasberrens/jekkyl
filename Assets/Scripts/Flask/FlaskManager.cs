using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FlaskManager : MonoBehaviour
{
        [Serializable]
        public struct FlaskSprite {
                public Sprite Sprite;
                public bool correctCombination;
        }
        
        
        [SerializeField] private FlaskSprite[] flaskSprites;
        private List<TubeColors> currentTubes = new List<TubeColors>();
        private EventManager _eventManager;

        private void Start()
        {
                _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        }

        private void Update()
        {
                
        }

        public void AddTube(TubeColors tubeColor)
        {
                if (tubeColor == TubeColors.EMPTY) return;
                if (currentTubes.Count.Equals(0))
                {
                        _eventManager.OnCombiningFlasks?.Invoke();
                }
                currentTubes.Add(tubeColor);

                if (CorrectCombination())
                {
                        gameObject.GetComponent<SpriteRenderer>().sprite = flaskSprites[flaskSprites.Length - 1].Sprite;
                        _eventManager.CorrectFlaskCombination?.Invoke();
                        _eventManager.OnRoomWin?.Invoke();
                        Debug.Log("Correct combination");
                        return;
                }
                
                SetRandomSprite();

        }

        private void PrintCurrentTubes()
        {
                foreach (TubeColors tubeColors in currentTubes)
                {
                        Debug.Log("Tube: " + tubeColors);
                }
        }

        private void SetRandomSprite()
        {
                Random r = new Random();
                int rInt = r.Next(0, flaskSprites.Length - 2);

                Sprite newSprite = flaskSprites[rInt].Sprite;
                gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }

        public EventManager GetEventManager()
        {
                return _eventManager;
        }

        public bool IsFlaskFull()
        {
                return currentTubes.Count >= 3;
        }

        private bool CorrectCombination()
        {
                return currentTubes.Contains(TubeColors.BLUE) && currentTubes.Contains(TubeColors.PURPLE) && currentTubes.Contains(TubeColors.GREEN);
        }
}
