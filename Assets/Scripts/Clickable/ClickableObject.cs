using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    
    private Material originalMaterial;
    private MeshRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        if (m_Renderer == null) return;
        originalMaterial = m_Renderer.material;
    }

    private void OnMouseOver()
    {
        OnMouseEnterLogic();
        HandleOutlineEffect(true);

        if (CanClickObject() && Input.GetMouseButtonDown(0))
        {
            OnClickObjectLogic();
        }
    }

    private void OnMouseExit()
    {
        OnMouseExitLogic();
        HandleOutlineEffect(false);
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

    public abstract void OnMouseEnterLogic();
    public abstract void OnMouseExitLogic();
    public abstract void OnClickObjectLogic();
    public abstract bool CanClickObject();

}
