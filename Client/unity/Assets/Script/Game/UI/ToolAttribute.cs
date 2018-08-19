using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using usercmd;
using HiGame;
public class ToolAttribute : MonoBehaviour {
    private bool isEnable = false;
    public bool ISEnable {
        get {
            return isEnable;
        }
    }
    public void SetButtonAble()
    {
        isEnable = true;
        this.GetComponent<Button>().interactable = true;
    }
    public void SetButtonDisable()
    {
        isEnable = false;
        this.GetComponent<Button>().interactable = false;
    }
    public void OnClick()
    {
        UseItemC2SMsg msg = new UseItemC2SMsg();
       
        
        var currentToolImage=this.GetComponent<Image>().sprite;
        if (currentToolImage == UIData.spriteList[UIData.DYEING_TOOL])
        {
            Debug.Log("music changeColor");
            AkSoundEngine.PostEvent("color_change", BattleRoom.GetInstance().playerList[UIData.playerId].GameObject);
            this.GetComponent<Image>().sprite = UIData.spriteList[UIData.ORIGINAL_TOOL];

            msg.item = itemType.dyeing;

        }
        else if (currentToolImage == UIData.spriteList[UIData.DIZZY_TOOL])
        {
            msg.item = itemType.dizzy;
            this.GetComponent<Image>().sprite = UIData.spriteList[UIData.ORIGINAL_TOOL];
        }
        else if (currentToolImage == UIData.spriteList[UIData.VIRUS_TOOL])
        {
            AkSoundEngine.PostEvent("trap_setup", BattleRoom.GetInstance().playerList[UIData.playerId].GameObject);
            msg.item = itemType.virus;
            this.GetComponent<Image>().sprite = UIData.spriteList[UIData.ORIGINAL_TOOL];
        }
        else if (currentToolImage == UIData.spriteList[UIData.SPEED_TOOL])
        {
            msg.item = itemType.speedup;
            this.GetComponent<Image>().sprite = UIData.spriteList[UIData.ORIGINAL_TOOL];
        }
        this.SetButtonDisable();
        MsgHandler.Send((int)DemoTypeCmd.PlayerUseItem, msg);

    }
}
