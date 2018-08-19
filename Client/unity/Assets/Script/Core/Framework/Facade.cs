//****************************************************************************
// Description:静态管理类
// 对外接口,tick管理
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public class Facade
    {
        
        private static GameTick gameTick;
        public static GameTick GameTick
        {
            get
            {
                if (gameTick == null)
                {
                    gameTick = new GameTick();
                }

                return gameTick;
            }
        }

       
        public static void Dispose()
        {
            GameTick.Dispose();
            gameTick = null;
        }
    }
}