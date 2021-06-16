using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskManager : MonoBehaviour
{
        [Serializable]
        public struct FlaskSprite {
                public Sprite Sprite;
                public bool correctCombination;
        }
        
        
        [SerializeField] private FlaskSprite[] flaskSprites;
        private List<TubeColors> currentTubes = new List<TubeColors>();
        
        private void Start()
        {
                
        }

        private void Update()
        {
                
        }

        public void AddTube(TubeColors tubeColor)
        {
                if (tubeColor == TubeColors.EMPTY) return;
                currentTubes.Add(tubeColor);
        }
}
