using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    
    private void OnMouseOver()
    {
        OnMouseEnterLogic();
        if (CanClickObject() && Input.GetMouseButtonDown(0))
        {
            OnClickObjectLogic();
        }
    }

    private void OnMouseExit()
    {
        OnMouseExitLogic();
    }

    public abstract void OnMouseEnterLogic();
    public abstract void OnMouseExitLogic();
    public abstract void OnClickObjectLogic();
    public abstract bool CanClickObject();

}
