//****************************************************************************
// Description: 非mono组件基类
// 主要用于通用逻辑及销毁
// Author: hiramtan@qq.com
//***************************************************************************

using System;

namespace HiFramework
{
    public abstract class ObjectBase : IDisposable
    {
        protected abstract void OnDispose();
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
     
        ~ObjectBase()
        {
            Dispose(false);
        }
        private void Dispose(bool paramDisposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (paramDisposing)
            {
                OnDispose();
            }

            this.disposed = true;
        }
    }
}