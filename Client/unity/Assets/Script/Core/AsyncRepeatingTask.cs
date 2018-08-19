//****************************************************************************
// Description:间隔时间执行
// Author: hiramtan@qq.com
//***************************************************************************
using System;
using GameBox.Framework;
using UnityEngine;

namespace HiGame.Core
{
    public class AsyncRepeatingTask : AsyncTask
    {
        private readonly Action<object> action;
        private readonly object obj;
        private readonly float repeatingTime;
        private bool isStop;
        private float timeStart;

        public AsyncRepeatingTask(Action<object> action, float repeating, object obj=null) : base(false)
        {
            this.action = action;
            this.repeatingTime = repeating;
            this.obj = obj;
            this.timeStart = Time.realtimeSinceStartup;
        }

        public void Stop()
        {
            this.isStop = true;
        }

        protected override bool IsDone()
        {
            if (Time.realtimeSinceStartup >= this.timeStart + this.repeatingTime)
            {
                this.timeStart = Time.realtimeSinceStartup;
                action(obj);
            }

            return this.isStop;
        }
    }
}