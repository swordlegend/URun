using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiGame;
using usercmd;
public class UIMessege {

    public   void Init()
    {
        MsgHandler.Regist((int)DemoTypeCmd.LoginRes, OnLogin);
        MsgHandler.Regist((int)DemoTypeCmd.SearchRes, OnSearch);
        MsgHandler.Regist((int)DemoTypeCmd.DyeingCmd, OnDyeing);
        MsgHandler.Regist((int)DemoTypeCmd.DisDyeingCmd, OnDisDyeing);
        MsgHandler.Regist((int)DemoTypeCmd.MatchRes, OnMatch);
        // MsgHandler.Regist((int)DemoTypeCmd.GameEnergy, OnEnergy);
     //   MsgHandler.Regist((int)DemoTypeCmd.MoveRes, OnMove);
    }
    private void OnLogin(IProto iProto)
    {   // GameWorld.Instance.RunOnMainThread()
        //var msg = iProto.Get<LoginS2CMsg>();
        //UIData.playerId = msg.playerId;
        //UIManage.GetInstance().SetUnVisvible("UI_Login");
        //UIManage.GetInstance().SetVisvible("UI_Search");
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var temp = x as IProto;
            var msg = temp.Get<LoginS2CMsg>();
            UIData.playerId = msg.playerId;
            //Debug.Log("Write playerId");
            UIManage.GetInstance().SetUnVisvible("UI_Login");
            UIManage.GetInstance().SetVisvible("UI_Search");

        }, iProto);
        //GameObject.Find("UIRoot")
        //GameWorld.Instance.RunOnMainThread
        //(x =>
        //{
        //    var tempProto = x as IProto;
        //    var msg = tempProto.Get<LoginS2CMsg>();
        //    UIData.playerId = msg.playerId;
        //    //GameObject.Find("Canvas").transform
        //}, iProto
        //);

    }
    private void OnSearch(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            UIManage.GetInstance().SetUnVisvible("UI_Search");
            UIManage.GetInstance().SetUnVisvible("UI_InSearch");
        }, null);
     
        var msg = iProto.Get<SearchS2CMsg>();
        Dictionary<uint, string> searchResult = new Dictionary<uint, string>();
        for (int i = 0; i < msg.nums.Count; i++)
        {
            searchResult.Add(msg.nums[i].playerId, msg.nums[i].name);
        }
        BattleRoom.GetInstance().Search(msg.roomId, searchResult);
        //UIManage.GetInstance().SetVisvible("UI_Go");      
    }
    private void OnDyeing(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            
            var msg = (x as IProto).Get<DyeingS2CMsg>();
            colorType _color = BattleRoom.GetInstance().playerList[msg.activeId].color;
            Debug.Log(_color);
            switch (BattleRoom.GetInstance().playerList[msg.activeId].color)
            {
                case colorType.red:
                    var dyeingRed = ObjPool.Instance.GetObjInPlayer("DyeingWorkRed", (int)msg.activeId);
                    dyeingRed.RootObj.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                    dyeingRed.Dispose(1.0f);
                    Debug.Log("Dyeing red"+msg.activeId);
                    break;
                case colorType.yellow:
                    var dyeingYellow = ObjPool.Instance.GetObjInPlayer("DyeingWorkYellow", (int)msg.activeId);
                    dyeingYellow.RootObj.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                    dyeingYellow.Dispose(1.0f);
                    Debug.Log("Dyeing Yellow" + msg.activeId);
                    break;
                case colorType.blue:
                    var dyeingBlue = ObjPool.Instance.GetObjInPlayer("DyeingWorkBlue", (int)msg.activeId);
                    dyeingBlue.RootObj.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                    dyeingBlue.Dispose(1.0f);
                    Debug.Log("Dyeing blue" + msg.activeId);
                    break;
                default:
                    break;
            }
            switch (_color)
            {
                case colorType.red:
                    ObjBase  dyeingEyeRed = ObjPool.Instance.GetObjInPlayer("DyeingEyeRed", (int)msg.passiveId);
                    dyeingEyeRed.RootObj.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
                    dyeingEyeRed.Dispose(6);
                    break;
                case colorType.yellow:
                    Debug.Log("case yellow");
                    ObjBase dyeingEyeYellow = ObjPool.Instance.GetObjInPlayer("DyeingEyeYellow", (int)msg.passiveId);
                    dyeingEyeYellow.RootObj.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
                    dyeingEyeYellow.Dispose(6);
                    break;
                case colorType.blue:
                    ObjBase dyeingEyeBlue = ObjPool.Instance.GetObjInPlayer("DyeingEyeBlue", (int)msg.passiveId);
                    dyeingEyeBlue.RootObj.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
                    dyeingEyeBlue.Dispose(6);
                    break;
            }            
            //Debug.Log("被染色的玩家"+msg.passiveId);
            //Debug.Log("释放染色道具的玩家" + msg.activeId);
            //Debug.Log("染成了什么颜色" + msg.color);
        }
        , iProto);

    }
    private void OnDisDyeing(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            var msg = (x as IProto).Get<DisDyeingS2CMsg>();
            //Debug.Log("被染色的玩家已经解除了被染色" + msg.passiveId);
            //Debug.Log("被染色的玩家原来是什么颜色" + msg.color);
        }
        , iProto);

    }
    private void OnMatch(IProto iProto)
    {
        GameWorld.Instance.RunOnMainThread(x =>
        {
            MatchS2CMsg msg = new MatchS2CMsg();
            msg = (x as IProto).Get<MatchS2CMsg>();
            
            UIManage.GetInstance().GetUI("UI_InSearch").GetComponent<UI_InSearch>().SetNum((int)msg.currentNum, (int)msg.totalNum);
           
        }
        , iProto);
    }
}
