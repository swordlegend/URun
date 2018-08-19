//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public interface ITick
    {
        void Add(ITick paramTick);
        void Remove(ITick paramTick);
        void OnTick();
    }
}