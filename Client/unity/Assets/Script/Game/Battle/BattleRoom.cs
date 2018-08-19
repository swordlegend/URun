using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using usercmd;
using HiGame;
public class BattleRoom {
    private static BattleRoom instance = null;
    public static BattleRoom GetInstance()
    {
       
        if (instance == null)
        {
            instance = new BattleRoom();
            instance.Init();
        }
        return instance;
    }
    public uint roomId;
    public uint playerNums;
    public void Init()
    {
        BattleMessege.GetInstance().Init();
        playerList = new Dictionary<uint, Player>();
    }


    //创建小地图Flag
    public GameObject CreateFlagInMinMap(Sprite _sprite)
    {
        GameObject flagInMiniMap = new GameObject("flagInMiniMap");
        flagInMiniMap.AddComponent<SpriteRenderer>().sprite = _sprite;
        flagInMiniMap.transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
        flagInMiniMap.layer = LayerMask.NameToLayer("MiniMap");
        return flagInMiniMap;
    }
    //匹配信息
    private Dictionary<uint, string> searchPlayers;
    public void Search(uint _roomId,Dictionary<uint,string> _searchPlayers)
    {
        roomId = _roomId;
        playerNums = (uint)_searchPlayers.Count;
        searchPlayers = _searchPlayers;
    }


    public Dictionary<uint, Player> playerList;
    //创建玩家
    public void CreatePlayers(uint playerId, uint i, uint j, colorType _color)
    {
        Vector3 _pos = GetVec2FromIJ((int)i, (int)j);
        _pos.y = 2.0f;
        string nameInfo = "";
        int IndexFlag =UIData.RED_PLAYER;
        switch (_color)
        {
            case colorType.red:
                nameInfo = "_Red";
                IndexFlag = UIData.RED_PLAYER;
                break;
            case colorType.blue:
                nameInfo = "_Blue";
                IndexFlag = UIData.BLUE_PLAYER;
                break;
            case colorType.yellow:
                nameInfo = "_Yellow";
                IndexFlag = UIData.YELLOW_PLAYER;
                break;
            default:
                nameInfo = "";
                break;
        }
        GameObject go = GameObject.Instantiate(Resources.Load("Prefab/Player" +UIData.PlayerModel+ nameInfo)) as GameObject;
        go.name = "Model";
        GameObject flagInMiniMap = CreateFlagInMinMap(UIData.spriteList[IndexFlag]);
        Player player = new Player(go,flagInMiniMap, _color);
        //player.RootObj.AddComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
        player.SetParent(GameObject.Find("BattleRoom/PlayerList").transform);
        player.SetPosition(_pos.x,_pos.y,_pos.z);
        player.RootObj.name = "player" + playerId.ToString();
        player.GameObject.transform.localPosition = Vector3.zero;
        //GameObject obj = new GameObject("player" + playerId.ToString());
        //obj.transform.position = _pos;
        //obj.transform.SetParent(GameObject.Find("BattleRoom/PlayerList").transform);
        ////Player player = new Player(GameObject.Instantiate(Resources.Load("Prefab/Player"+nameInfo), 
        ////    _pos,
        ////    Quaternion.identity,
        ////    GameObject.Find("BattleRoom/PlayerList").transform) as GameObject,_color) ;
        
        //Player player = new Player(obj, _color);
        //GameObject.Instantiate(Resources.Load("Prefab/Player" + nameInfo), player.GameObject.transform).name = "Model";

        playerList.Add(playerId, player);

        //为主角添加光柱
        GameObject brightSprite = new GameObject("brightSprite");
        switch (_color)
        {
            case colorType.red:
                brightSprite.AddComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.PLAYERRED_BRIGHT];
                break;
            case colorType.yellow:
                brightSprite.AddComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.PLAYERYELLOW_BRIGHT];
                break;
            case colorType.blue:
                brightSprite.AddComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.PLAYERBLYUE_BRIGHT];
                break;
        }
        brightSprite.transform.SetParent(playerList[playerId].RootObj.transform);
        brightSprite.transform.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
        brightSprite.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        if (UIData.playerId == playerId)
        {


            //UIData.playerColor = _color;
           // var flagHero = CreateFlagInMinMap(UIData.spriteList[UIData.HERO_PLAYER]);
           //flagHero.transform.SetParent(playerList[playerId].RootObj.transform);
           // flagHero.transform.localPosition = new Vector3(0.0f,5.0f,0.0f);

            //为主角添加摄像机
            GameObject MainCamera = new GameObject("MainCamera");
            MainCamera.transform.Rotate(Vector3.right, 90.0f);
            MainCamera.transform.SetParent(playerList[playerId].RootObj.transform);
            MainCamera.AddComponent<Camera>();
            MainCamera.transform.localPosition = new Vector3(0, 4, -4);
            MainCamera.transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
            MainCamera.GetComponent<Camera>().orthographic = false;
            MainCamera.GetComponent<Camera>().fieldOfView = 60;
            MainCamera.GetComponent<Camera>().nearClipPlane = 1.0f;
            MainCamera.GetComponent<Camera>().farClipPlane = 500.0f;
            MainCamera.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default");
            MainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
            //音频
           
            switch (playerList[UIData.playerId].color)
            {
                case colorType.red:
                    MusicManager.instance.SetPlayerColor("red");
                    break;
                case colorType.yellow:
                    MusicManager.instance.SetPlayerColor("green");
                    break;
                case colorType.blue:
                    MusicManager.instance.SetPlayerColor("blue");
                    break;
            }           
            ////为主角添加主角光环
            //GameObject spotLight = new GameObject("spotLight");
            //spotLight.AddComponent<Light>();
            //spotLight.transform.SetParent(playerList[playerId].RootObj.transform);
            //spotLight.transform.localPosition = new Vector3(0.0f, 10.0f, 0.0f);
            //spotLight.transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
            //spotLight.GetComponent<Light>().type = LightType.Spot;
            //spotLight.GetComponent<Light>().spotAngle = 15;
            //spotLight.GetComponent<Light>().range = 25;
            //spotLight.GetComponent<Light>().intensity = 8;
            
            //switch (_color)
            //{
            //    case colorType.yellow:
            //        spotLight.GetComponent<Light>().color = new Color32(105, 255, 92, 255);                 
            //        break;
            //    case colorType.red:
            //        spotLight.GetComponent<Light>().color = new Color32(255, 150, 157, 255);             
            //        break;
            //    case colorType.blue:
            //        spotLight.GetComponent<Light>().color = new Color32(73, 97, 255, 255);              
            //        break;
            //    case colorType.origin:
            //        spotLight.GetComponent<Light>().color = new Color32(255, 255, 255, 255);
            //        break;
            //    default:
            //        spotLight.GetComponent<Light>().color = new Color32(255, 255, 255, 255);
            //        break;
            //}
        }

    }


    //道具信息
    public void GetItem(itemType _itemType)
    {
        UIManage.GetInstance().GetUI("UI_ToolList").GetComponent<UI_Tool>().AddItemInPool(_itemType);      
    }
    //创建道具在房间中
    public void CreateTool(int i,int j, itemType type)
    {
        Vector3 pos = GetVec2FromIJ(i, j);
        Tool tool;

        switch (type)
        {
            case itemType.unknown:
                tool=ToolPool.Instance.GetObject(itemType.unknown,i,j);
                tool.RootObj.transform.position = (GetVec2FromIJ(i, j)+new Vector3(0.0f,1.0f,0.0f));
                //Debug.Log("创建道具"+i.ToString()+"."+j.ToString());
                break;
            case itemType.dyeing:               
                break;
            case itemType.virus:
                break;
            default:
                break;
        }


    }
    public Vector3 GetVec2FromIJ(int i, int j)
    {
        //
        float z = i* TerrainManage.GetInstance().bounds.extents.z * 2 + GameObject.Find("BattleRoom/Terrain/CellRoot").transform.position.z;
        float x = j * TerrainManage.GetInstance().bounds.extents.x * 2 + GameObject.Find("BattleRoom/Terrain/CellRoot").transform.position.x;
        Vector3 pos = new Vector3(x, 1.1f, z);
        return pos;
    }



    //创建病毒
    public void CreateVirus(string name,int i, int j)
    {
       var virus=ParticlePool.Instance.GetParticleObj(name,i,j);
        virus.RootObj.name = "Virus" + i.ToString() + j.ToString();
        virus.SetPosition(GetVec2FromIJ(i, j));
    }
    //
    public  void Clear()
    {
       
        GameObject.Destroy(GameObject.Find("BattleRoom"));
        instance = null;
    }

    //private void TimeWaitGo()
    //{ }
    
}
