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
    [SerializeField] private float FadeTime = 1f;

    [SerializeField] private Sprite OpenSafeImage;
    [SerializeField] private GameObject Key;

    private GameObject SafeCanvas;

    private GameObject Safe;
    // Start is called before the first frame update
    void Start()
    {
        SafeCanvas = GameObject.FindWithTag("SafeCanvas");
        _textObject = GameObject.FindWithTag("SafeText");
        Safe = GameObject.FindWithTag("SafeBig");
        _text = _textObject.GetComponent<Text>();
        _text.text = "";
        _text.color = Color.cyan;

        Key.active = false;
        
        SafeCanvas.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNumber(Button button)
    {
         
        if (_text.text.Length >= 4) return;
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
        Key.active = false;
        StartCoroutine(FadeImage(false));
    }

    private void OnCodeCorrect()
    {
        Transform[] childrenObjects = SafeCanvas.GetComponentsInChildren<Transform>();

        foreach (Transform transform in childrenObjects)
        {
            GameObject gameObject = transform.gameObject;
            Debug.Log(gameObject.name);
            if (gameObject.name.Equals(SafeCanvas.name)) continue;
            if (gameObject.name.Equals(Safe.name)) continue;
            gameObject.active = false;
        }

        Safe.GetComponent<Image>().sprite = OpenSafeImage;
        Key.active = true;
    }

    IEnumerator SetCodeText()
    {
        string text;
        Color color;
        if (IsInputRight())
        {
            text = "You won!";
            color = Color.green;
            OnCodeCorrect();
        }
        else
        {
            CurrentTries++;
            if (CurrentTries >= MaxTries)
            {
                text = "Tried too much";
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
    
    IEnumerator FadeImage(bool fadeAway)
    {
        Image image = Safe.GetComponent<Image>();
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = FadeTime; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }

            Safe.active = false;
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= FadeTime; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }

        }
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
