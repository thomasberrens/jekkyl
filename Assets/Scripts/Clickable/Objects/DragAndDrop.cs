using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : ClickableObject
{

    private Vector3 originalPosition;

    private bool isDragging;

    [SerializeField] private GameObject Target;
    [SerializeField] private Sprite EmptyTubeSprite;
    [SerializeField] private TubeColors TubeColor;

    private FlaskManager _flaskManager;

    private bool CanDrop;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
        TubeColors type = ParseEnum<TubeColors>(gameObject.name);
        _flaskManager = GameObject.FindWithTag("Flask Manager").GetComponent<FlaskManager>();
        if (type == null)
        {
            Debug.Log("There is something wrong with: " + gameObject.name);
            return;
        }

        TubeColor = type;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            OnDrag();
        }
        
    }
    
    public T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }

    public override void OnMouseEnterLogic()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnEndDrag();
        }
    }

    private void OnEndDrag()
    {
        if (CanDrop)
        {
            Debug.Log("Able to drop");
            gameObject.GetComponent<SpriteRenderer>().sprite = EmptyTubeSprite;
        }
        
        gameObject.transform.position = originalPosition;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Equals(Target.name)) return;
        CanDrop = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.name.Equals(Target.name)) return;
        CanDrop = false;

    }

    private void OnDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        gameObject.transform.position = mousePosition;
    }

    public override void OnMouseExitLogic()
    {
       
    }

    public override void OnClickObjectLogic()
    {
       
    }

    public override bool CanClickObject()
    {
        return false;
    }
}
