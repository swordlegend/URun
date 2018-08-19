using GameBox.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HiGame.Core
{
    public class AsyncWWWTask : AsyncTask
    {
        private WWW www;
        private Action<WWW> wwwEvent;

        public AsyncWWWTask(Action<WWW> wwwEvent, string url, byte[] data = null, Dictionary<string, string> cookies = null) : base(false)
        {
            this.wwwEvent = wwwEvent;
            if (cookies == null)
            {
                if (data == null)
                {
                    this.www = new WWW(url);
                }
                else
                {
                    this.www = new WWW(url, data);
                }
            }
            else
            {
                this.www = new WWW(url, data, cookies);
            }
        }

        protected override bool IsDone()
        {
            if (this.www.isDone)
            {
                this.wwwEvent(this.www);

                return true;
            }

            return false;
        }
    }
}