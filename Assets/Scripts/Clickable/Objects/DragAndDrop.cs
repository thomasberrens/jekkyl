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
    private Sprite OriginalSprite;
    [SerializeField] private TubeColors CurrentTubeColor;
    private TubeColors OriginalTubeColor;

    private FlaskManager _flaskManager;

    private EventManager _eventManager;

    private bool CanDrop;
    // Start is called before the first frame update
    void Start()
    {
        OriginalSprite = GetComponent<SpriteRenderer>().sprite;
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        originalPosition = gameObject.transform.position;
        TubeColors type = ParseEnum<TubeColors>(gameObject.name);
        _flaskManager = GameObject.FindWithTag("Flask Manager").GetComponent<FlaskManager>();
        if (type == null)
        {
            Debug.Log("There is something wrong with: " + gameObject.name);
            return;
        }

        CurrentTubeColor = type;
        OriginalTubeColor = type;
        
        FindObjectOfType<TubeManager>().AddTubeInRoom(gameObject);

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

    public void ResetTube()
    {
        GetComponent<SpriteRenderer>().sprite = OriginalSprite;
        CurrentTubeColor = OriginalTubeColor;
    }

    private void OnEndDrag()
    {
        if (CanDrop)
        {
            _eventManager.OnFlaskFill?.Invoke();
            Debug.Log("Able to drop");
            if (_flaskManager.IsFlaskFull())
            {
                Debug.Log("Full");
                _eventManager.InCorrectFlaskCombination?.Invoke();
                _eventManager.OnRoomLose?.Invoke();
                SetTubeToOriginalPosition();
                return;
            }

            _flaskManager.AddTube(CurrentTubeColor);
            gameObject.GetComponent<SpriteRenderer>().sprite = EmptyTubeSprite;
            CurrentTubeColor = TubeColors.EMPTY;
        }
        SetTubeToOriginalPosition();
    }

    private void SetTubeToOriginalPosition()
    {
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
