using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManage : MonoBehaviour {
    public int _edgeNum;
    private static TerrainManage _instance;
    public static TerrainManage GetInstance()
    {
        if (_instance == null)
        {
            GameObject Terrain = GameObject.Instantiate(Resources.Load("Prefab/Terrain"),Vector3.zero,Quaternion.identity,GameObject.Find("BattleRoom").transform) as GameObject;
            Terrain.name = "Terrain";
            Terrain.AddComponent<TerrainManage>();
            _instance = Terrain.GetComponent<TerrainManage>();
        }
        return _instance;
    }
    public List<List<Cell>> cellList=new List<List<Cell>>();
    public void CreateTerrain(int edgeNum)
    {
        _edgeNum = edgeNum;
       // Debug.Log("CreateTerrain");
        //GameObject terrain = GameObject.Find("BattleRoom/Terrain");
        GameObject terrain = GameObject.Find("Terrain");
        GameObject cellInstance = terrain.transform.Find("Cell").gameObject;
        //GameObject wallList = new GameObject("WallList");
        //wallList.transform.SetParent(terrain.transform);
        //wallList.transform.localPosition = new Vector3(9.5f, 0.0f, 9.5f);
        //GameObject leftWall = new GameObject("leftWall");
        //leftWall.transform.localPosition = new Vector3(-10.0f, 0.0f, 10);
        //leftWall.AddComponent<BoxCollider>();
   
        for (int i = 0; i < edgeNum; i++)
        {
            List<Cell> tempCellList = new List<Cell>();
            for (int j = 0; j < edgeNum; j++)
            {
                if (i == 0 && j == 0)
                {
                    //GameObject obj = new GameObject("Cell" + i.ToString() + j.ToString());
                    //Cell cell =new Cell(obj);
                    //GameObject obj2=GameObject.Instantiate(Resources.Load("Prefab/Cell"), obj.transform) as GameObject;
                    //obj2.transform.SetParent(cell.GameObject.transform);
                    //GameObject flagInMiniMap=GameObject.
                    var flagInMinMap=BattleRoom.GetInstance().CreateFlagInMinMap(UIData.spriteList[UIData.ORIGINAL_CELL]);
                    Cell cell = new Cell(cellInstance, flagInMinMap);              
                    cell.SetPosition(0, 0, 0);
                    cell.RootObj.transform.SetParent(terrain.transform);
                    tempCellList.Add(cell);
                }
                else               
                {
                    //Cell cell = new Cell(GameObject.Instantiate(
                    //Resources.Load("Prefab/Cell"),
                    //new Vector3(terrain.transform.position.x + j * cellInstance.GetComponent<MeshRenderer>().bounds.size.x,
                    //0.0f, 
                    //terrain.transform.position.z+ i * cellInstance.GetComponent<MeshRenderer>().bounds.size.z),
                    //Quaternion.AngleAxis(90.0f,Vector3.right),
                    //terrain.transform) as GameObject);
                    //cell.GameObject.GetComponent<CellAttribute>().col = j;
                    //cell.GameObject.GetComponent<CellAttribute>().row = i;
                    //tempCellList.Add(cell);
                    // Debug.Log(cell.GameObject.GetComponent<SpriteRenderer>().bounds);

                    float posY=0.0f;
                    var s = Random.value;
                    if (s < 0.3)
                    {
                        posY = 0.2f;
                    }
                    else if (s < 0.6f)
                    {
                        posY = 0.4f;
                    }
                    else if (s <0.9f)
                    {
                        posY = 0.7f;
                    }
                    else
                    {
                        posY = 0.6f;
                    }

                    var flagInMinMap = BattleRoom.GetInstance().CreateFlagInMinMap(UIData.spriteList[UIData.ORIGINAL_CELL]);
                    GameObject go = GameObject.Instantiate(Resources.Load("Prefab/Cell")) as GameObject;             
                    Cell cell = new Cell(go, flagInMinMap);
                   
                    cell.SetPosition(terrain.transform.position.x + j * cellInstance.GetComponent<MeshRenderer>().bounds.size.x,
                          posY,
                        terrain.transform.position.z + i * cellInstance.GetComponent<MeshRenderer>().bounds.size.z);
                    cell.GameObject.GetComponent<CellAttribute>().col = j;
                    cell.GameObject.GetComponent<CellAttribute>().row = i;
                    cell.SetParent(terrain.transform);
                    flagInMinMap.transform.localPosition = new Vector3(0, 2.0f, 0.0f);
                    tempCellList.Add(cell);
                }
               
            }
            cellList.Add(tempCellList);
        }
        bounds = cellList[0][0].GameObject.GetComponent<MeshRenderer>().bounds;
        
       //var leftBottomCell = cellList[0][0].RootObj.transform.position;
       // var rightTopCell= cellList[edgeNum-1][edgeNum-1].RootObj.transform.position;
       // GameObject wallLeft = new GameObject("wallLeft");
       // wallLeft.transform.position = new Vector3(leftBottomCell.x - 1.0f, 0.0f, leftBottomCell.z - 0.5f + 0.5f * edgeNum);
       // wallLeft.AddComponent<BoxCollider>().size = new Vector3(1.0f, edgeNum , edgeNum);
       // GameObject wallRight = new GameObject("wallRight");
       // wallRight.transform.position = new Vector3(rightTopCell.x + 1.0f, 0.0f, rightTopCell.z + 0.5f - 0.5f * edgeNum);
       // wallRight.AddComponent<BoxCollider>().size = new Vector3(1.0f, edgeNum, edgeNum);
       // GameObject wallTop = new GameObject("wallTop");
       // wallTop.transform.position = new Vector3(rightTopCell.x + 0.5f-0.5f*edgeNum, 0.0f, rightTopCell.z+1.0f);
       // wallTop.AddComponent<BoxCollider>().size = new Vector3(edgeNum, edgeNum, 1.0f);
       // GameObject wallBottom = new GameObject("wallBottom");
       // wallBottom.transform.position = new Vector3(leftBottomCell.x - 0.5f + 0.5f * edgeNum, 0.0f, leftBottomCell.z-1.0f);
       // wallBottom.AddComponent<BoxCollider>().size = new Vector3(edgeNum, edgeNum, 1.0f);
        
    }
    public Bounds bounds;
    public void Clear()
    {
        _instance = null;
    }
}
