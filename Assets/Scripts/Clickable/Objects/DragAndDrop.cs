using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : ClickableObject
{

    private Vector3 originalPosition;

    private bool isDragging;
    

    [SerializeField] private GameObject Target;

    private bool CanDrop;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            OnDrag();
        }
        
    }

    public override void OnMouseEnterLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("skkrrrrt");
            isDragging = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("lossseeeee");
            isDragging = false;
            OnEndDrag();
        }
    }

    private void OnEndDrag()
    {
        if (CanDrop)
        {
            Debug.Log("Able to drop");
        }
        else
        {
            gameObject.transform.position = originalPosition;
        }
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
