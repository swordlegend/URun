//****************************************************************************
// Description:一段时间后执行
// Author: hiramtan@qq.com
//****************************************************************************

using GameBox.Framework;
using System;
using UnityEngine;

namespace HiGame.Core
{
    public class AsyncTimeTask : AsyncTask
    {
        private float startTime;
        private float time;
        private Action action;

        public AsyncTimeTask(Action action, float time) : base(false)
        {
            this.startTime = Time.realtimeSinceStartup;
            this.action = action;
            this.time = time;
        }

        protected override bool IsDone()
        {
            bool isTrue = Time.realtimeSinceStartup > this.startTime + this.time;
            if (isTrue)
            {
                if (this.action == null)
                {
                    AnyLogger.X(new Exception("you regist a async time task, but have no callback"));
                }

                this.action();
            }

            return isTrue;
        }
    }
}
