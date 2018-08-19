//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using GameBox.Framework;
using System;
using UnityEngine;

public class AsyncPingTask : AsyncTask
{
    private float timeStart;
    private Ping ping;
    private Action<int> action;
    private string ip;
    private float timeOut;

    public AsyncPingTask(Action<int> action, string ip, float timeOut) : base(false)
    {
        this.timeStart = Time.realtimeSinceStartup;
        this.action = action;
        this.ip = ip;
        this.timeOut = timeOut;
        this.ping = new Ping(this.ip);
    }

    protected override bool IsDone()
    {
        if (Time.realtimeSinceStartup - this.timeStart > timeOut)
        {
            action(this.ping.time);
            this.timeStart = Time.realtimeSinceStartup;
            this.ping.DestroyPing();
            ping = null;
            this.ping = new Ping(ip);
        }
        return false;
    }
}