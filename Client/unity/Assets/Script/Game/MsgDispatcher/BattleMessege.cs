using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiGame;
using usercmd;
using UnityEngine.UI;
public struct PlayerItem
{
    public int cellNums;
    public  colorType color;
    public  string name;
    public int playerId;
}
public class BattleMessege  {
    private int preRow=-1;
    private int preCol=-1;
    //private moveType curMoveType = moveType.idle;
    private static BattleMessege instance;
    public static BattleMessege GetInstance()
    {
        if (instance ==null)
        {
            instance = new BattleMessege();
        }
        return instance;
    }
    public  void Init()
    {
        MsgHandler.Regist((int)DemoTypeCmd.GameStart, OnGameStart);
        MsgHandler.Regist((int)DemoTypeCmd.MoveRes,OnMove);
        MsgHandler.Regist((int)DemoTypeCmd.ChangeColorRes, OnChangeColor);
        MsgHandler.Regist((int)DemoTypeCmd.GameEnergy,OnEnergy);
        MsgHandler.Regist((int)DemoTypeCmd.ItemCreate,OnItemCreate);
        MsgHandler.Regist((int)DemoTypeCmd.ItemDestroy, OnItemDestroy);
        MsgHandler.Regist((int)DemoTypeCmd.GameTime, OnUpdateTime);
        MsgHandler.Regist((int)DemoTypeCmd.PlayerGetItem, OnGetItem);
        MsgHandler.Regist((int)DemoTypeCmd.VirusCreate, OnVirusCreate);
        MsgHandler.Regist((int)DemoTypeCmd.PlayerImprison, OnImPrison);
        MsgHandler.Regist((int)DemoTypeCmd.VirusDestroy, OnVirusDestroy);
        MsgHandler.Regist((int)DemoTypeCmd.GameEnd, OnGameEnd);
        MsgHandler.Regist((int)DemoTypeCmd.PlayerDizzy, OnPlayerDizzy);
        MsgHandler.Regist((int)DemoTypeCmd.PlayerSpeedUp, OnPlayerSpeedUp);
        //DemoTypeCmd.DyeingCmd
    }
    private void OnGameStart(IProto iProto)
    {

        GameWorld.Instance.RunOnMainThread
       (x =>
       {

           MusicManager.instance.GameStart();
          
           UIManage.GetInstance().SetUnVisvible("UI_Search");
           UIManage.GetInstance().SetVisvible("UI_ToolList");
           UIManage.GetInstance().SetVisvible("UI_Keyboard");
           UIManage.GetInstance().SetVisvible("UI_Up");
           UIManage.GetInstance().SetVisvible("MiniMap");
           UIManage.GetInstance().SetUnVisvible("UI_InSearch");

           var tempProto = x as IProto;
           var msg = tempProto.Get<GameStartS2CMsg>();
           TerrainManage.GetInstance().CreateTerrain((int)msg.edgenum);

           GameObject PlayerList = new GameObject("PlayerList");
           PlayerList.transform.SetParent(GameObject.Find("BattleRoom").transform);

           GameObject ToolList = new GameObject("ToolList");
           ToolList.transform.SetParent(GameObject.Find("BattleRoom").transform);

           GameObject OtherList = new GameObject("OtherList");
           OtherList.transform.SetParent(GameObject.Find("BattleRoom").transform);

           for (int i = 0; i < msg.nums.Count; i++)
           {
               BattleRoom.GetInstance().CreatePlayers(msg.nums[i].playerId,msg.nums[i].row, msg.nums[i].col, msg.nums[i].color);
           }
           Debug.Log("..");
           UIManage.GetInstance().SetVisvible("UI_Go");
            GameWorld.Instance.startCoroutine(UIManage.GetInstance().GetUI("UI_Go").GetComponent<UI_Go>().StartTimeWait());
       }, iProto
       );

    }
    private void OnMove(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread
        (x =>
        {
            //Debug.Log("BrightAndDark");
            var tempProto = x as IProto;
            var msg = tempProto.Get<MoveS2CMsg>();
            if (preRow == -1 && preCol == -1)
            {
                preRow = (int)msg.row;
                preCol = (int)msg.col;
            }
            else if(preRow!=msg.row||preCol!=msg.col)
            {
                //Debug.Log("当前"+msg.row.ToString() + "..." + msg.col.ToString());
                //Debug.Log("上一个"+preRow.ToString() + "..." + preCol.ToString());

                TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].BrightSelf();
                TerrainManage.GetInstance().cellList[(int)preRow][(int)preCol].DarkSelf();
                preRow = (int)msg.row;
                preCol = (int)msg.col;
            }

            //if (curMoveType != msg.mType && UIData.playerId != msg.playerId)
            //{
            //    switch (msg.mType)
            //    {
            //        case moveType.idle:
            //            BattleRoom.GetInstance().playerList[UIData.playerId].GameObject.GetComponent<Animator>().SetInteger("x", 0);
            //            curMoveType = msg.mType;
            //            break;
            //        case moveType.left:
            //            BattleRoom.GetInstance().playerList[UIData.playerId].GameObject.GetComponent<Animator>().SetInteger("x", 1);
            //            curMoveType = msg.mType;
            //            break;
            //        case moveType.right:
            //            BattleRoom.GetInstance().playerList[UIData.playerId].GameObject.GetComponent<Animator>().SetInteger("x", 2);
            //            curMoveType = msg.mType;
            //            break;
            //    }


            //}

            if (msg.playerId != UIData.playerId)
            {
                if (!BattleRoom.GetInstance().playerList.ContainsKey(msg.playerId))
                {
                    return;
                    //
                }
                BattleRoom.GetInstance().playerList[msg.playerId].UpdatePosition(msg.posX, msg.posY, msg.posZ);
            }
        },iProto
        );
    }
    private void OnChangeColor(IProto iProto)
    {
       // Debug.Log("变色 Receive");
        GameWorld.Instance.RunOnMainThread
      (x =>
      {
          var tempProto = x as IProto;
          var msg = tempProto.Get<ChangeColorS2CMsg>();
          //Debug.Log(msg.row.ToString() + "行" + msg.col.ToString() + "列变色");
          TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].setColor(msg.color);
          TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].ActionAnimation();
          //AkSoundEngine.PostEvent("color_change", TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].GameObject);
          //AkSoundEngine.PostEvent("color_change")
      }, iProto
      );
    }
    private void OnEnergy(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<GameEnergyS2CMsg>();
            var UI_Energy = UIManage.GetInstance().UIROOT.transform.Find("UI_Up").gameObject;
            switch (msg.color)
            {
                //case colorType.origin:              
                //    MusicManager.instance.SetLeadingPlayer("")
                //    break;
                case colorType.red:
                    MusicManager.instance.SetLeadingPlayer("red");
                    break;
                case colorType.yellow:
                    MusicManager.instance.SetLeadingPlayer("green");
                    break;
                case colorType.blue:
                    MusicManager.instance.SetLeadingPlayer("blue");
                    break;
            }
            if (msg.lastColor == BattleRoom.GetInstance().playerList[UIData.playerId].color)
            {
                MusicManager.instance.PlayerIsTrailing(true);
            }
            else
            {
                MusicManager.instance.PlayerIsTrailing(false);
            }

            if (!UI_Energy.activeInHierarchy)
            {
                UIManage.GetInstance().SetVisvible("UI_Up");
            }
            UI_Energy.GetComponent<UI_UpControl>().setEnergy(msg.color, (int)msg.status);
        }, iProto);
    }
    private void OnItemCreate(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            
            var msg = (x as IProto).Get<CreateItemsS2CMsg>();
            BattleRoom.GetInstance().CreateTool((int)msg.row,(int)msg.col, msg.item);

        }, iProto);

    }
    private void OnItemDestroy(IProto iProto)
    {
        //Debug.Log("销毁道具消息收到");
        GameWorld.Instance.RunOnMainThread(x =>
        {

            var msg = (x as IProto).Get<DestroyItemsS2CMsg>();
            //Debug.Log("销毁道具"+msg.row.ToString()+"."+msg.col.ToString());
            ToolPool.Instance.Dispose((int)msg.row,(int)msg.col);
            Debug.Log("销毁" + msg.row + msg.col);
        }, iProto);

    }
    private void OnUpdateTime(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<SynTimeS2CMsg>();
            
            UIManage.GetInstance().GetUI("UI_Up").GetComponent<UI_UpControl>().UpdateTime((int)msg.minute,(int)msg.second);
        }, iProto);

    }
    private void OnGetItem(IProto iProto)
    {

        Debug.Log("Get Item");
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<GetItemS2CMsg>();
            //Debug.Log("GetItem1");
            BattleRoom.GetInstance().GetItem(msg.item);
            //Debug.Log("GetItem2");
            AkSoundEngine.PostEvent("pickup_item", BattleRoom.GetInstance().playerList[UIData.playerId].GameObject);     
           
            switch (msg.item)
            {
                case itemType.dizzy:
                    string toolName1 = "神魂颠倒";
                    UIManage.GetInstance().GetUI("UI_Up").GetComponent<UI_UpControl>().showTips("获得道具" + toolName1 + ":随机对手操控方向相反",2.0f);
                    break;
                case itemType.dyeing:
                    string toolName2 = "染色";
                    UIManage.GetInstance().GetUI("UI_Up").GetComponent<UI_UpControl>().showTips("获得道具" + toolName2 + ":周围玩家有一定概率暂时被染色", 2.0f);
                    break;
                case itemType.virus:
                    string toolName3 = "病毒";
                    UIManage.GetInstance().GetUI("UI_Up").GetComponent<UI_UpControl>().showTips("获得道具" + toolName3 + "释放五个眩晕病毒", 2.0f);
                    break;
                case itemType.speedup:
                    string toolName4 = "加速";
                    UIManage.GetInstance().GetUI("UI_Up").GetComponent<UI_UpControl>().showTips("获得道具" + toolName4 + "玩家速度提升一段时间", 2.0f);
                    break;
            }
        }, iProto);
    }
    private void OnVirusCreate(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<VirusCreateS2CMsg>();
            //BattleRoom.GetInstance().CreateVirus("TeXiao1",(int)msg.row,(int)msg.col);
            TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].RendTool(itemType.virus);
        }, iProto);
    }
    private void OnVirusDestroy(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<VirusDestroyS2CMsg>();
        
            TerrainManage.GetInstance().cellList[(int)msg.row][(int)msg.col].DesTroyTool();
        }, iProto);
    }
    private void OnImPrison(IProto iProto)
    {
        Debug.Log(" Disable Move MSg");
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<PlayerImprisonS2CMsg>();
            //var thunder =ParticlePool.Instance.GetParticleObjInPlayer("Thunder",(int)msg.playerId);
            ////thunder.RootObj.name = "Thunder";
            ////thunder.Dispose(msg.time);
            var virusWork = ObjPool.Instance.GetObjInPlayer("VirusWorkAnimation", (int)msg.playerId);
            virusWork.Dispose(msg.time);
            AkSoundEngine.PostEvent("trap_triggered", BattleRoom.GetInstance().playerList[UIData.playerId].GameObject);
            //virusWork.Dispose(msg.time);
            if (msg.playerId == UIData.playerId)
            {
           
                UIManage.GetInstance().GetUI("UI_Keyboard").GetComponent<UI_Keyboard>().DisableMove((int)msg.time);
            }
        }, iProto);
        
    }
    private void OnGameEnd(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            UIManage.GetInstance().SetUnVisvible("UI_Up");
            UIManage.GetInstance().SetUnVisvible("UI_Keyboard");
            UIManage.GetInstance().SetUnVisvible("UI_ToolList");
            UIManage.GetInstance().SetUnVisvible("MiniMap");
            UIManage.GetInstance().SetVisvible("UI_GameEnd");
            //Debug.Log("func 0");
            var msg = (x as IProto).Get<GameEndS2CMsg>();
            List<PlayerItem> playerItemList = new List<PlayerItem>();
            for (int i = 0; i < msg.nums.Count; i++)
            {
                PlayerItem playerItem = new PlayerItem();
                playerItem.cellNums =(int)msg.nums[i].cellnum;
                playerItem.color = msg.nums[i].color;
                playerItem.name = msg.nums[i].name;
                playerItem.playerId =(int)msg.nums[i].playerId;
                playerItemList.Add(playerItem);
            }
            //Debug.Log("func 0");
            int mvpId =(int)msg.mvpid;
            colorType winColor=msg.winColor;
            //Debug.Log("Func1");
            if (winColor == BattleRoom.GetInstance().playerList[UIData.playerId].color)
            {
                MusicManager.instance.Win();
            }
            else
            {
                MusicManager.instance.Lose();
            }
            UIManage.GetInstance().GetUI("UI_GameEnd").gameObject.GetComponent<UI_GameEnd>().SetGameEndData(playerItemList,winColor,mvpId);
            UIManage.GetInstance().GetUI("UI_GameEnd").gameObject.GetComponent<UI_GameEnd>().Show();
            
            //Debug.Log("Func2");
        }, iProto);

    }
    private void OnPlayerDizzy(IProto iProto)
    {
        //Debug.Log("Dizzy receive");
        GameWorld.Instance.RunOnMainThread(x =>
        {

  
          
            var msg = (x as IProto).Get<PlayerDizzyS2CMsg>();
            
            //var virusWork = ObjPool.Instance.GetObjInPlayer("VirusWorkAnimation", (int)msg.playerId);
            AkSoundEngine.PostEvent("reverse_direction", BattleRoom.GetInstance().playerList[msg.playerId].GameObject);
            var dizzyWork = ObjPool.Instance.GetObjInPlayer("DizzyWork", (int)msg.playerId);
            dizzyWork.Dispose(msg.time);
            //virusWork.Dispose(msg.time);
            if (msg.playerId == UIData.playerId)
            {
                UIManage.GetInstance().GetUI("UI_Keyboard").GetComponent<UI_Keyboard>().Dizzy(msg.time);
            }
        }, iProto);

    }
    private void OnPlayerSpeedUp(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<PlayerSpeedUpS2CMsg>();
            var obj=ObjPool.Instance.GetObjInPlayer("speedWork",(int)msg.playerId);
            obj.RootObj.transform.localPosition = new Vector3(0.0f, 2.0f, 0.0f);
            obj.Dispose(msg.time);
            if (msg.playerId == UIData.playerId)
            {

                UIManage.GetInstance().GetUI("UI_Keyboard").GetComponent<UI_Keyboard>().SpeedUp((int)msg.speedNum, msg.time);

            }

        }, iProto);

    }
    public void Clear()
    {
        instance = null;
    }
    

}
