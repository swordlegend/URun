using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour {
    private static UIManage _instance;
    public static UIManage GetInstance()
    {
        if (_instance == null)
        {
            Debug.LogError("UIManage Created Error!");
            return null;
        }
        return _instance;

    }
    private void Awake()
    {
        _instance = this;
        UIRoot = this.gameObject;
    }
    private GameObject UIRoot;
    public GameObject UIROOT
    {
        get {
            return UIRoot;
        }
        set {
            UIRoot = value;
        }
        }
    public void SetVisvible(string objName)
    {
        //可视检测:优化
        //if (UIRoot.transform.Find(objName).gameObject.activeInHierarchy)
        //{
           
        //    return;
        //}
        
        UIRoot.transform.Find(objName).gameObject.SetActive(true);
    }
    public void SetUnVisvible(string objName)
    {
        UIRoot.transform.Find(objName).gameObject.SetActive(false);
    }
    public Transform GetUI(string path_name)
    {
       return UIRoot.transform.Find(path_name);
    }
}
