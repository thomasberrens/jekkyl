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
    public UnityEvent DoneWithBookFade;
    public UnityEvent CorrectFlaskCombination;
    public UnityEvent InCorrectFlaskCombination;
    public UnityEvent OnCombiningFlasks;
    public UnityEvent OnBookOpen;
    public UnityEvent OnRoomSwitch;
    public UnityEvent OnSafeCodeCorrect;
    public UnityEvent OnSafeOpen;
    public UnityEvent OnFlaskFill;
    public UnityEvent OnTubeReset;

    private void Start()
    {
    }
}
