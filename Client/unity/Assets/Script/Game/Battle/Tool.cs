using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;
public class FlagInMiniMap:ObjectBase
{
    public GameObject flagInMiniMap;
}
public  class Tool: ObjectBase{
    public int row;
    public int col;
    private itemType _toolType;
    public itemType ToolType {
        get {
            return _toolType;
        }
    }
    //道具起作用
    public Tool(int i, int j)
    {
        row = i;
        col = j;
    }
    public virtual void Work()
    {

    }

    public void SetPostionInTerrain(int _row, int _col)
    {
        row = _row;
        col = _col;
       Vector3 pos=BattleRoom.GetInstance().GetVec2FromIJ(_row, _col);
        this.RootObj.transform.position = pos;
    }
}

public class ParticleObj : ObjectBase {
    public int row;
    public int col;
    //public string particleObj
    private string name;
    public string Name {
        get {
            return name;
        }
    }
    
    public ParticleObj(string _name,int i,int j)
    {
        name = _name;
        RootObj = new GameObject("ParticleRoot");
        RootObj.transform.SetParent(UnityEngine.GameObject.Find("BattleRoom/OtherList").transform);
        GameObject = UnityEngine.GameObject.Instantiate(Resources.Load("TeXiao/" + name), RootObj.transform) as UnityEngine.GameObject;
        GameObject.name = "ParticleModel";
        row = i;
        col = j;
    }
    public ParticleObj(string _name)
    {
        name = _name;
        RootObj = new GameObject("ParticleRoot");
        RootObj.transform.SetParent(UnityEngine.GameObject.Find("BattleRoom/OtherList").transform);
        GameObject = UnityEngine.GameObject.Instantiate(Resources.Load("TeXiao/" + name), RootObj.transform) as UnityEngine.GameObject;
        GameObject.name = "ParticleModel";
    }
}
public class ToolUnknown :Tool{
    public ToolUnknown(int i,int j):base(i,j)
    {
       
        RootObj = new GameObject("ToolRoot");
        RootObj.transform.SetParent(UnityEngine.GameObject.Find("BattleRoom/ToolList").transform);

        GameObject =UnityEngine.GameObject.Instantiate(Resources.Load("Prefab/Tool"),RootObj.transform) as UnityEngine.GameObject;
        GameObject.name = "ToolModel";
        //Debug.Log("Local Position");
        RootObj.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public override void Work()
    {
        Debug.Log("ToolType1 work");
    }
}
public class ToolType2:Tool
{
    public ToolType2(int i, int j) : base(i, j)
    {
    }
    public override void Work()
    {
        Debug.Log("ToolType2 work");
    }
}
public class ToolType3:Tool
{
    public ToolType3(int i, int j) : base(i, j)
    {

    }
    public override void Work()
    {
        Debug.Log("ToolType3 work");
    }
}