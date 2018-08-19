//****************************************************************************
// Description:游戏中的tick管理
// Author: hiramtan@qq.com
//****************************************************************************
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick :ObjectBase, ITick
    {
        private IList<ITick> ticks = new List<ITick>();

        public void OnTick()
        {
            for (int i = 0; i < ticks.Count; i++)
            {
                this.ticks[i].OnTick();
            }
        }

        public void Add(ITick paramTick)
        {
            if (!this.ticks.Contains(paramTick))
            {
                this.ticks.Add(paramTick);
            }
        }

        public void Remove(ITick paramTick)
        {
            if (this.ticks.Contains(paramTick))
            {
                this.ticks.Remove(paramTick);
            }
        }

        protected override void OnDispose()
        {
            this.ticks.Clear();
            this.ticks = null;
        }
    }
}