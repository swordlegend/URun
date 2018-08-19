//****************************************************************************
// Description:派发消息内容
// Author: hiramtan@qq.com
//****************************************************************************
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class Message : ObjectBase, IMessage
    {
        public string Key { get; private set; }
        public List<object> Msg { get; private set; }

        public Message(string paramKey, params object[] param)
        {
            this.Key = paramKey;
            this.Msg = new List<object>(param);
        }

        protected override void OnDispose()
        {
            this.Msg.Clear();
            this.Msg = null;
        }
    }
}