
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using usercmd;
public class ObjBase:ObjectBase {
private  string   name;
    public string Name
    {
        get {
            return name;
        }
        set {
            name = value;
        }
    }
    public ObjBase(string _name)
    {
        
        name = _name;
        RootObj = new GameObject(name);
        GameObject = UnityEngine.GameObject.Instantiate(Resources.Load("Prefab/ObjBaseList/" + name) as GameObject);
        GameObject.SetActive(true);
        GameObject.name = "Model";
        GameObject.transform.SetParent(RootObj.transform);
        GameObject.transform.localPosition = Vector3.zero;
    }
}
public class ObjPool {
    private static ObjPool _instance;
    public static ObjPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ObjPool();
            }
            return _instance;
        }
    }
    public List<ObjBase> objPool = new List<ObjBase>();
    public ObjBase GetObjInPlayer(string _name, int _playerId)
    {
        for (int i = 0; i < objPool.Count; i++)
        {
            if (!objPool[i].IsUsed && objPool[i].RootObj.name == _name)
            {
                objPool[i].RootObj.SetActive(true);
                objPool[i].IsUsed = true;
                BattleRoom.GetInstance().playerList[(uint)_playerId].AddToSelf(objPool[i]);
                return objPool[i];
            }
         
        }
        ObjBase obj = new ObjBase(_name);
        BattleRoom.GetInstance().playerList[(uint)_playerId].AddToSelf(obj);
        obj.IsUsed = true;
        objPool.Add(obj);
        return obj;
    }
    public void Clear()
    {
        _instance = null;
    }
}
public class ToolPool {
    private static ToolPool _instance;
    public static ToolPool Instance {
        get {
            if (_instance == null)
            {
                _instance = new ToolPool();
            }
            return _instance;
        }
    }
    public List<Tool> toolPool=new List<Tool>();
    public Tool GetObject(itemType _toolType,int row, int col)
    {
        for (int i = 0; i < toolPool.Count; i++)
        {
            if (!toolPool[i].IsUsed && toolPool[i].ToolType == _toolType)
            {
                toolPool[i].RootObj.SetActive(true);
                toolPool[i].IsUsed = true;
                toolPool[i].SetPostionInTerrain(row, col);
                return toolPool[i];
            }
        }
        Tool _tool=new Tool(row,col);
        switch (_toolType)
        {
            case itemType.unknown:
                _tool = new ToolUnknown(row, col);
                //_tool.RootObj.transform
                _tool.IsUsed = true;
                toolPool.Add(_tool);
                return _tool;
               
            case itemType.dyeing:
                _tool = new ToolType2(row,col);
                _tool.IsUsed = true;
                toolPool.Add(_tool);
                return _tool;
            case itemType.virus:
                _tool = new ToolType3(row,col);
                _tool.IsUsed = true;
                toolPool.Add(_tool);
                return _tool;
            default:
                break;
        }
        
        return _tool;
    }
    public void Dispose(int row, int col)
    {
        for (int i = 0; i < toolPool.Count; i++)
        {
            if (toolPool[i].IsUsed && toolPool[i].row == row && toolPool[i].col == col)
            {
                Debug.Log("销毁"+row.ToString()+col.ToString());
                toolPool[i].Dispose();
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < toolPool.Count; i++)
        {
         toolPool[i].Destroy();
        }
        toolPool.Clear();
        _instance = null;
    }
}
public class ParticlePool {
    private static ParticlePool _instance;
    public static ParticlePool Instance {
        get {
            if (_instance == null)
            {
                _instance = new ParticlePool();
            }
            return _instance;
        }
    }
    public List<ParticleObj> particlePool = new List<ParticleObj>();
    public ParticleObj GetParticleObj(string name, int row, int col)
    {
        for (int i = 0; i < particlePool.Count; i++)
        {
            if (!particlePool[i].IsUsed && particlePool[i].Name == name)
            {
                particlePool[i].GameObject.SetActive(true);
                particlePool[i].IsUsed = true;
                return particlePool[i];
            }
        }
        ParticleObj obj = new ParticleObj(name, row, col);
        obj.IsUsed = true;
        particlePool.Add(obj);
        return obj;
    }
    public ParticleObj GetParticleObjInPlayer(string name, int PlayerId)
    {
        for (int i = 0; i < particlePool.Count; i++)
        {
            if (!particlePool[i].IsUsed && particlePool[i].Name == name)
            {
                particlePool[i].RootObj.SetActive(true);
                particlePool[i].IsUsed = true;
                BattleRoom.GetInstance().playerList[(uint)PlayerId].AddToSelf(particlePool[i]);
                return particlePool[i];
            }
        }
        ParticleObj obj = new ParticleObj(name);
        BattleRoom.GetInstance().playerList[(uint)PlayerId].AddToSelf(obj);
        obj.IsUsed = true;
        particlePool.Add(obj);
        return obj;
    }
    public void Dispose(int row, int col)
    {
        for (int i = 0; i < particlePool.Count; i++)
        {
            if (particlePool[i].IsUsed && particlePool[i].row == row && particlePool[i].col == col)
            {
                particlePool[i].Dispose();
            }
        }
    }
    //public void Dispose(int playerId,string equipmentName)
    //{
    //    Transform obj = GameObject.Find("BattleRoom/PlayerList/player" + playerId.ToString() + "/" + equipmentName).transform;
    //    if (obj!=null)
    //    {

    //    }
    //}
    public void Clear()
    {
        particlePool.Clear();
        _instance = null;
    }
}
public interface Obj {
     void Dispose();   
}
public class ObjectBase : Obj
{
    private bool isUsed = false;
    public bool IsUsed
    {
        get
        {
            return isUsed;
        }
        set
        {
            isUsed = value;
        }
    }
    GameObject rootObj;
    GameObject obj;
    public GameObject GameObject
    {
        set { obj = value; }
        get { return obj; }
    }
    public GameObject RootObj
    {
        set { rootObj = value; }
        get { return rootObj; }
    }
    public ObjectBase()
    {
        obj = null;
    }
    public void Destroy()
    {
        GameObject.Destroy(rootObj);
        
    }
    public void Dispose()
    {
        //Debug.Log(this.GameObject.transform.position);
        isUsed = false;
        this.rootObj.SetActive(false);
    }
    public void Dispose(float time)
    {
        GameWorld.Instance.startCoroutine(WaitSomeSeconds(time));
    }
    public void SetParent(Transform _tranform)
    {
        this.RootObj.transform.SetParent(_tranform);
    }
    public void SetPosition(float x, float y, float z)
    {
        RootObj.transform.position = new Vector3(x, y, z);
    }
    public void SetPosition(Vector3 _pos)
    {
        RootObj.transform.position = _pos;
    }
    IEnumerator WaitSomeSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        this.Dispose();
        yield return null;
    }
}
