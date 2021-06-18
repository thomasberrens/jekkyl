using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaasObject : ClickableObject
{

    private GameObject broken_vase;
    // Start is called before the first frame update
    void Start()
    {
        broken_vase = GameObject.FindGameObjectWithTag("brokenvase");
        if (IsVaseBroken())
        {
            broken_vase.active = true;
            gameObject.active = false;
            return;
        }
        
        broken_vase.active = false;
    }

    private bool IsVaseBroken()
    {
        return SaveManager.AllData.Contains("brokenvase");
    }

    private void SaveData()
    {
        SaveManager.WriteString("brokenvase");
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
        gameObject.active = false;
        broken_vase.active = true;
        OnMouseExit();
        SaveData();
        GameObject.FindWithTag("EventManager").GetComponent<EventManager>().OnBreakVase?.Invoke();
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
