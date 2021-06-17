using System;
using System.Collections;
using UnityEngine;

namespace Clickable.Objects
{
    public class ResetTubeObject : ClickableObject
    {
        private Color OriginalColor;

        private bool Resetting;

        private void Start()
        {
            OriginalColor = GetComponent<SpriteRenderer>().color;
            
        }

        public override void OnMouseEnterLogic()
        {
            
        }

        public override void OnMouseExitLogic()
        {
           
        }

        public override void OnClickObjectLogic()
        {
           FindObjectOfType<TubeManager>().ResetAllTubesInRoom();
           StartCoroutine(InteractWithReset());
        }

        public override bool CanClickObject()
        {
            return true;
        }
        
        IEnumerator InteractWithReset()
        {
            Resetting = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            float elapsedTime = 0;
            float waitTime = .2f;
            while (elapsedTime < waitTime)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            GetComponent<SpriteRenderer>().color = OriginalColor;
            Resetting = false;
            yield return null;
        }
    }
}