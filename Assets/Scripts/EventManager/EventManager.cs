using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent OnItemPickup;
    public UnityEvent OnRoomWin;
    public UnityEvent OnRoomLose;
    public UnityEvent OnBreakVase;
    public UnityEvent DoneWithFade;

    private void Start()
    {
    }
}
