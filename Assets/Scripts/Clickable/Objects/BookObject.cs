using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookObject : ClickableObject
{
    private GameObject BookOpen;
    [SerializeField] private GameObject Key;
    
    [SerializeField] private float FadeTime = 1f;

    private GameObject EventManager;
    // Start is called before the first frame update
    void Start()
    {
        EventManager = GameObject.FindWithTag("EventManager");
        BookOpen = GameObject.FindWithTag("BookOpen");
        // _imageColor = BookOpen.GetComponent<SpriteRenderer>().color;
        BookOpen.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMouseEnterLogic()
    {
        
    }

    public override void OnMouseExitLogic()
    {
        
    }

    public override void OnClickObjectLogic()
    {
        BookOpen.active = true;
        EventManager.GetComponent<EventManager>().OnBookOpen?.Invoke();
        StartCoroutine(FadeImage(false));
    }

    public override bool CanClickObject()
    {
        return true;
    }

    public void FadeOut()
    {
       StartCoroutine(FadeImage(true));
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
                
                BookOpen.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            
            BookOpen.active = false;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= FadeTime; i += Time.deltaTime)
            {
                // set color with i as alpha

                BookOpen.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            
            EventManager.GetComponent<EventManager>().DoneWithBookFade?.Invoke();

        }
    }
}
