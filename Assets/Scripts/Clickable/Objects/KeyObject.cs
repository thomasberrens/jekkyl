using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyObject : ClickableObject
{
    private GameObject RoomManager;

    private EventManager EventManager;

    [SerializeField] private float FadeTime = 1f;

    private bool found = false;
    // Start is called before the first frame update
    void Start()
    {
        RoomManager = GameObject.Find("RoomManager");
        EventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        gameObject.active = false;
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
        Checklist checklist = RoomManager.GetComponent<Checklist>();
        checklist.OnItemPickup(gameObject);
        gameObject.active = false;
        OnMouseExit();
        SetFound(true);
    }

    public override bool CanClickObject()
    {
        return true;
    }

    public void SetKeyActive()
    {
        if (IsObjectFound()) return;
        
        gameObject.active = true;
    }

    public void ShowKey()
    {
        FadeKey(false);
    }

    public void FadeKeyAway()
    {
        FadeKey(true);
    }

    public void FadeKey(bool fadeAway)
    {
        if (IsObjectFound()) return;
        
        gameObject.active = true;
        StartCoroutine(FadeImage(fadeAway));
        
    }

    IEnumerator FadeImage(bool fadeAway)
    {
       
        // fade from opaque to transparent
        if (fadeAway)
        {
            
            // loop over 1 second backwards
            for (float i = FadeTime; i >= 0; i -= Time.deltaTime)
            {
               
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                
                // set color with i as alpha
                
                yield return null;
            }
            gameObject.active = false;
            
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= FadeTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
