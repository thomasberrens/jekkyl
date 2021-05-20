using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   [SerializeField] public Text timer;
    public float time = 20;
    float msec;
    float sec;
    float min;

    private EventManager _eventManager;
    
    private void Start()
    {
        _eventManager = GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>();
        StartCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        bool TimerOn = true;
        while (TimerOn)
        {
            if (time <= 0) TimerOn = false;
            time -= Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
            
            yield return null;
        }
        Debug.Log("Lose - Timer off");
        _eventManager.OnRoomLose?.Invoke();
    }

    void Update()
    {


    }
}
