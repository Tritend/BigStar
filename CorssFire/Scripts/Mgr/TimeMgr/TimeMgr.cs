using UnityEngine;
using System;
using System.Collections.Generic;

public class TimerHandler
{
    private float timer = 0;
    private float endTime = 0;
    private Action handler;
    private bool isCall = false;
    private float callTime;
    private float callTimer = 0;
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            this.timer += value;
            callTimer += value;
            if (isCall && callTimer > callTime)
            {
                handler();
                callTimer = 0;
            }
            if (timer >= endTime)
            {
                handler();
                TimeMgr.Instance.removeTimerHanlder(this);
            }
        }
    }

    public TimerHandler(float end, Action handler)
    {
        this.endTime = end;
        this.handler = handler;
    }
    public TimerHandler(float end, bool isCall, float callTime, Action handler)
    {
        this.endTime = end;
        this.handler = handler;
        this.isCall = isCall;
        this.callTime = callTime;
    }
}


public class TimeMgr : MonoBehaviour
{
    public static TimeMgr Instance = null;
    private List<TimerHandler> handers = null;

    void Awake()
    {
        Instance = this;
        handers = new List<TimerHandler>();
    }

    public void setTimerHandler(TimerHandler timerHanlder)
    {
        handers.Add(timerHanlder);
    }
    public void removeTimerHanlder(TimerHandler timerHanlder)
    {
        if (handers.Contains(timerHanlder))
        {
            handers.Remove(timerHanlder);
        }
    }

    private void Update()
    {
        for (int i = 0; i < handers.Count; i++)
        {
            handers[i].Timer = Time.deltaTime;
        }
    }
}
