using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxClicks : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int MaxAmountOfClicks = 5;
    private EventManager EventManager;
    void Start()
    {
        EventManager = GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MaxAmountOfClicks <= 0)
        {
            Debug.Log("LOSE");
            EventManager.OnRoomLose?.Invoke();
        }
        if (Input.GetMouseButtonDown(0))
        {
            MaxAmountOfClicks--;
        }
    }
}
