using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    
    private Material originalMaterial;
    private MeshRenderer m_Renderer;

    public void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        Debug.Log("????");
        originalMaterial = m_Renderer.material;
    }

    private void OnMouseOver()
    {
        OnMouseEnterLogic();
        if (m_Renderer.material.Equals(originalMaterial))
        {
            m_Renderer.material = outlineMaterial;
        }
        
        if (CanClickObject() && Input.GetMouseButtonDown(0))
        {
            OnClickObjectLogic();
        }
    }

    private void OnMouseExit()
    {
        OnMouseExitLogic();
        if (!m_Renderer.material.Equals(originalMaterial))
        {
            m_Renderer.material = originalMaterial;
        }
    }

    public abstract void OnMouseEnterLogic();
    public abstract void OnMouseExitLogic();
    public abstract void OnClickObjectLogic();
    public abstract bool CanClickObject();

}
