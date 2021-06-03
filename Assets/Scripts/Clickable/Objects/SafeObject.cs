using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeObject : ClickableObject
{
    private GameObject _textObject;

    private Text _text;

    [SerializeField] private int code = 17042;

    [SerializeField] private int MaxTries = 3;
    [SerializeField] private int CurrentTries = 0;
    
    [SerializeField] private float waitTime = 1f;

    private GameObject SafeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        SafeCanvas = GameObject.FindWithTag("SafeCanvas");
        _textObject = GameObject.FindWithTag("SafeText");
        _text = _textObject.GetComponent<Text>();
        _text.text = "";
        _text.color = Color.cyan;
        SafeCanvas.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumber(Button button)
    {
         
        if (_text.text.Length > 4) return;
        _text.text += button.GetComponentInChildren<Text>().text;
    }

    public void CheckCode()
    {
        StartCoroutine(SetCodeText());
    }

    public void CloseSafe()
    {
        SafeCanvas.active = false;
    }
    
    private void OpenSafe()
    {
        SafeCanvas.active = true;
    }

    IEnumerator SetCodeText()
    {

        string text;
        Color color;
        
        if (IsInputRight())
        {
            text = "You won!";
            color = Color.green;
        }
        else
        {
            CurrentTries++;
            if (CurrentTries >= MaxTries)
            {
                text = "You tried too many times";
                color = Color.grey;
            }
            else
            {
                text = "Wrong";
                color = Color.red;
            }
        }
        
        float elapsedTime = 0;
        while (elapsedTime < waitTime)
        {
            _text.text = text;
            _text.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _text.text = "";
        _text.color = Color.cyan;
        yield return null;
    }

    public bool IsInputRight()
    {
        return _text.text.Equals(code.ToString());
    }

    public override void OnMouseEnterLogic()
    {
    
    }

    public override void OnMouseExitLogic()
    {
      
    }

    public override void OnClickObjectLogic()
    {
        OpenSafe();
    }

    public override bool CanClickObject()
    {
        return true;
    }
}
