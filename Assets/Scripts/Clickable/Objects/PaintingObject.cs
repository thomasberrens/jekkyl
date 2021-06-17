using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class PaintingObject : ClickableObject
{
    [SerializeField] private Sprite NewSprite;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.AllData.Contains("painting_fallen"))
        {
            OnClickObjectLogic();
        }
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
        GameObject.FindWithTag("Room").GetComponent<SpriteRenderer>().sprite = NewSprite;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        SaveManager.WriteString("painting_fallen");
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
