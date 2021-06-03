using System;
using UnityEngine;
public class MousePointer : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private CursorMode cursorMode = CursorMode.Auto;
    
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }
}
