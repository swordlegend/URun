using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;
using HiGame;
using UnityEngine.UI;
public class UI_Tool : MonoBehaviour {
    ////private GameObject ToolButton1;
    ////private void Start()
    ////{
    ////    ToolButton1 = this.transform.Find("Tool_Dyeing").gameObject;
    ////}
    //List<KeyValuePair<GameObject, bool>> UITools = new List<KeyValuePair<GameObject, bool>>();
    ////所有的ToolUI

    //private void Start()
    //{
    //    for (int i = 0; i < this.transform.childCount; i++)
    //    {
    //        UITools.Add(new KeyValuePair<GameObject,bool>(this.transform.GetChild(i).gameObject,false));
    //        UITools[i].Key.GetComponent<ToolAttribute>().SetButtonDisable();
    //    }
    //}


    //public void AddItemInPool(itemType item)
    //{
    //    for (int i = 0; i < UITools.Count; i++)
    //    {
    //        if (!UITools[i].Value)
    //        {

    //            UITools[i] = new KeyValuePair<GameObject, bool>(UITools[i].Key, true);
    //            UITools[i].Key.GetComponent<ToolAttribute>().SetButtonAble();
    //            switch (item)
    //            {
    //                case itemType.unknown:
    //                    UITools[i].Key.GetComponent<Image>().sprite = UIData.spriteList[UIData.UNKONWN_TOOL];
    //                    break;
    //                case itemType.dyeing:
    //                    UITools[i].Key.GetComponent<Image>().sprite = UIData.spriteList[UIData.DYEING_TOOL];
    //                    break;
    //                case itemType.virus:
    //                    UITools[i].Key.GetComponent<Image>().sprite = UIData.spriteList[UIData.VIRUS_TOOL];
    //                    break;
    //                default:
    //                    break;
    //            }               
    //        }
    //    }
    //}
    public void AddItemInPool(itemType itemtype)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var Tool = this.transform.GetChild(i).gameObject;
            if (!Tool.GetComponent<ToolAttribute>().ISEnable)
            {
                Tool.GetComponent<ToolAttribute>().SetButtonAble();
                switch(itemtype)
                {
                    case itemType.unknown:
                        Debug.Log("获得unknown道具");
                      //Tool.GetComponent<Image>().sprite = UIData.spriteList[UIData.DIZZY_TOOL];
                        break;
                    case itemType.dyeing:
                        Tool.GetComponent<Image>().sprite = UIData.spriteList[UIData.DYEING_TOOL];
                        break;
                    case itemType.virus:
                        Tool.GetComponent<Image>().sprite = UIData.spriteList[UIData.VIRUS_TOOL];
                        break;
                    case itemType.dizzy:
                        Tool.GetComponent<Image>().sprite = UIData.spriteList[UIData.DIZZY_TOOL];
                        break;
                    case itemType.speedup:
                        Tool.GetComponent<Image>().sprite = UIData.spriteList[UIData.SPEED_TOOL];
                        break;
                    default:
                        break;
                }
                break;

            }
        }
    }

}
