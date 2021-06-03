using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    
    [SerializeField] private Texture2D CursorTextureOnHover;
    [SerializeField] private Texture2D CursorTextureOnClick;
    [SerializeField] private Texture2D OriginalCursorTexture;
    [SerializeField] private CursorMode cursorMode = CursorMode.Auto;
    
    private Material originalMaterial;
    private MeshRenderer m_Renderer;

    private bool IsHovering;
    private bool GrabTimer;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        if (m_Renderer == null) return;
        originalMaterial = m_Renderer.material;
    }

    private void OnMouseOver()
    {
        IsHovering = true;
        OnMouseEnterLogic();
        if (!GrabTimer)
        {
            Cursor.SetCursor(CursorTextureOnHover, Vector2.zero, cursorMode);
        }
        HandleOutlineEffect(true);
        if (CanClickObject() && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(GrabObject());
            OnClickObjectLogic();
        }
    }

    private void OnMouseExit()
    {
        IsHovering = false;
        OnMouseExitLogic();
        HandleOutlineEffect(false);
        Cursor.SetCursor(OriginalCursorTexture, Vector2.zero,  cursorMode);
    }

    private void HandleOutlineEffect(bool activate)
    {
        if (m_Renderer == null || outlineMaterial == null) return;

        if (activate)
        {
            if (m_Renderer.material.Equals(originalMaterial))
            {
                m_Renderer.material = outlineMaterial;
            }
        }
        else
        {
            if (!m_Renderer.material.Equals(originalMaterial))
            {
                m_Renderer.material = originalMaterial;
            } 
        }
    }
    
    IEnumerator GrabObject()
    {
        GrabTimer = true;
        Cursor.SetCursor(CursorTextureOnClick, Vector2.zero, cursorMode);
        float elapsedTime = 0;
        float waitTime = .2f;
        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (IsHovering)
        {
            Cursor.SetCursor(CursorTextureOnHover, Vector2.zero, cursorMode);
        }
        else
        {
            Cursor.SetCursor(OriginalCursorTexture, Vector2.zero,  cursorMode);
        } 

        GrabTimer = false;
        yield return null;
    }

    public abstract void OnMouseEnterLogic();
    public abstract void OnMouseExitLogic();
    public abstract void OnClickObjectLogic();
    public abstract bool CanClickObject();

}
