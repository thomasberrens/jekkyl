using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaseTrigger : MonoBehaviour
{
    private GameObject VaseCode;
    private Image image;
    private bool FadingOut;
    private bool FadingIn;
    [SerializeField] private float FadeTime = 1f;
    private void Start()
    {
        VaseCode = GameObject.FindWithTag("VaseCode");
        image = VaseCode.GetComponent<Image>();
        VaseCode.active = false;
    }

    public void FadeVase()
    {
        VaseCode.active = true;
        StartCoroutine(FadeImage(false));
    }

    public void FadeOutVase()
    {
        StartCoroutine(FadeImage(true));
    }

    private void Update()
    {
        
    }
    
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = FadeTime; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }

            VaseCode.active = false;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= FadeTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }

            GameObject.FindWithTag("EventManager").GetComponent<EventManager>().DoneWithFade?.Invoke();
        }
    }


    }

