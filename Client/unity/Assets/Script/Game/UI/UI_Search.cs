using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;
using HiGame;
public class UI_Search : MonoBehaviour {
    public GameObject UI_Root;
    public void OnSearch()
    {
        if (UIData.playerId != 10000)
        {
            UIManage.GetInstance().SetVisvible("UI_InSearch");
            SearchC2SMsg msg = new SearchC2SMsg();
            msg.playerId = UIData.playerId;
            //Debug.Log(msg.playerId);
            //Debug.Log(msg.playerId);
            //Debug.Log("Read PlayerId first");
            MsgHandler.Send((int)DemoTypeCmd.SearchReq, msg);
            this.gameObject.SetActive(false);
        }
    }
}
