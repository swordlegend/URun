using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using HiFramework;
public class GameWorld : MonoBehaviour {
    private void Awake()
    {
        instance = this;
    }
    private static GameWorld instance = null;
    public static GameWorld Instance
    {

        get
        {
            if (null == instance)
            {
                throw new Exception("GameWorld instance is not created!");
            }

            return instance;
        }
    }

    //退出游戏前需要执行的函数队列
    private List<Action> applicationQuitActions = new List<Action>();
    public void addInQuitActionList(Action action)
    {
        this.applicationQuitActions.Add(action);
    }
    public void OnApplicationQuit()
    {
        for (int i = 0; i < applicationQuitActions.Count; i++)
        {
            this.applicationQuitActions[i]();
        }
    }

    private Queue<ToExecute> toExecuteQueue = new Queue<ToExecute>();
    private static readonly object locker = new object();
    public void RunOnMainThread(Action<object> action, object obj)
    {
        lock (locker)
        {
            this.toExecuteQueue.Enqueue(new ToExecute(action, obj));
        }
    }


    private class ToExecute
    {
        public Action<object> Action { get; private set; }
        public object Obj { get; private set; }

        public ToExecute(Action<object> action, object obj)
        {
            this.Action = action;
            this.Obj = obj;
        }
    }
    // Use this for initialization
    void Start () {
        GameInit.GetInstance().InitGame();
		
	}
	
	// Update is called once per frame
	void Update () {
        Facade.GameTick.OnTick();
        if (this.toExecuteQueue.Count > 0)
        {
            while (this.toExecuteQueue.Count > 0)
            {
                var per = this.toExecuteQueue.Dequeue();
                per.Action(per.Obj);
            }
        }		
	}
    public void startCoroutine(IEnumerator ienum)
    {
          StartCoroutine(ienum);
    }
}
