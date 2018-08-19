using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiGame;
public class GameInit {
  
    private static GameInit instance=null;
    public static GameInit GetInstance()
    {
        if (instance == null)
        {
            instance = new GameInit();
        }
        return instance;
    }
    private TcpConnection tcp;
    private UIMessege uiMsg;
    public TcpConnection Tcp
    {
        get
        {
            if (tcp == null)
            {
                return null;
            }
            return tcp;
        }
        set {
            tcp = value;
        }

    }
    private void InitUIMessege()
    {
        uiMsg = new UIMessege(); 
        uiMsg.Init();
    }
    //private void InitTcpService()
    //{
    //    tcp = new TcpConnection();
    //}
    private void InitMaterial()
    {
        //预加载变色方格的材质
        UIData.materialList.Add(Resources.Load("Material/original", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/red", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/yellow", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/blue", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/ToolVirusRed", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/ToolVirusYellow", typeof(Material)) as Material);
        UIData.materialList.Add(Resources.Load("Material/ToolVirusBlue", typeof(Material)) as Material);

    }
    private void InitSprite()
    {
        //0-3:小地图玩家flag
        UIData.spriteList.Add(Resources.Load("Sprite/red", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/yellow", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/blue", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/hero", typeof(Sprite)) as Sprite);

        //4-7:小地图地图显示flag
        UIData.spriteList.Add(Resources.Load("Sprite/original_Cell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/red_Cell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/yellow_Cell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/blue_Cell", typeof(Sprite)) as Sprite);

        //8-11:电池Sprite
        UIData.spriteList.Add(Resources.Load("Sprite/Energy_RedCell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Energy_YellowCell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Energy_BlueCell", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Energy_OriginalCell", typeof(Sprite)) as Sprite);

        //12-14:道具Sprite
        UIData.spriteList.Add(Resources.Load("Sprite/Tool_Virus", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Tool_Dyeing", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Tool_Dizzy", typeof(Sprite)) as Sprite);
        

        //15-22:按钮Spite
        UIData.spriteList.Add(Resources.Load("Sprite/Button_UpBright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_DownBright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_LeftBright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_RightBright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_Up", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_Down", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_Left", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Button_Right", typeof(Sprite)) as Sprite);

        //23：道具原始Button
        UIData.spriteList.Add(Resources.Load("Sprite/Tool", typeof(Sprite)) as Sprite);
        
        //24-25:成功失败BgSprite
        UIData.spriteList.Add(Resources.Load("Sprite/SuccessBg", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/DefendBg", typeof(Sprite)) as Sprite);

        //26
        UIData.spriteList.Add(Resources.Load("Sprite/Color_Red", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Color_Yellow", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Color_Blue", typeof(Sprite)) as Sprite);
        //29-31
        UIData.spriteList.Add(Resources.Load("Sprite/PlayerRed_Bright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/PlayerGreen_Bright", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/PlayerBlue_Bright", typeof(Sprite)) as Sprite);

        //32-35
        UIData.spriteList.Add(Resources.Load("Sprite/Go3", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Go2", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Go1", typeof(Sprite)) as Sprite);
        UIData.spriteList.Add(Resources.Load("Sprite/Go", typeof(Sprite)) as Sprite);

        UIData.spriteList.Add(Resources.Load("Sprite/Tool_Speed", typeof(Sprite)) as Sprite);

    }
    private void InitResources()
    {

        InitMaterial();
        //预加载小地图玩家显示flag
        InitSprite();

    }
    public void InitGame()
    {
        //InitTcpService();
        InitUIMessege();
        InitResources();
        UIManage.GetInstance().SetVisvible("UI_Login");
    }
   
  
}
