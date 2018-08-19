using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using usercmd;
public class UI_GameEnd : MonoBehaviour {
    private  List<PlayerItem> _playerItemList=new List<PlayerItem>();
    private colorType _winColor;
    private int _mvpId;
    private List<GameObject> uiItemList=new List<GameObject>();
    void Start () {

	}
    public void Show()
    {
        if (BattleRoom.GetInstance().playerList[UIData.playerId].color == _winColor)
        {
            this.transform.Find("Bg").GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEENDSUCCESS_SPRITE];
        }
        else
        {
            this.transform.Find("Bg").GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEENDDEFEND_SPRITE];
        }
        for (int i = 0; i < _playerItemList.Count; i++)
        {
            uiItemList[i].transform.Find("Name").GetComponent<Text>().text = _playerItemList[i].name;
            uiItemList[i].transform.Find("CellNum").GetComponent<Text>().text = _playerItemList[i].cellNums.ToString();
            switch (_playerItemList[i].color)
            {
                case colorType.red:
                    uiItemList[i].transform.Find("Color").GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEENDCOLOR_RED];
                    break;
                case colorType.yellow:
                    uiItemList[i].transform.Find("Color").GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEENDCOLOR_YELLOW];
                    break;
                case colorType.blue:
                    uiItemList[i].transform.Find("Color").GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEENDCOLOR_BLUE];
                    break;
                default:
                    break;
            }
            if (_playerItemList[i].playerId == _mvpId)
            {
                uiItemList[i].transform.Find("Mvp").gameObject.SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetGameEndData(List<PlayerItem> playerItemList,colorType winColor,int mvpId)
    {

        for (int i = 0; i < this.transform.Find("Bg/ItemList").childCount; i++)
        {
            GameObject uiObj = this.transform.Find("Bg/ItemList").GetChild(i).gameObject;
            uiItemList.Add(uiObj);
        }
        _playerItemList = playerItemList;
        _winColor = winColor;
        _mvpId = mvpId;      
    }
    public void backToGameStart()
    {

        BattleRoom.GetInstance().Clear();
        ObjPool.Instance.Clear();
        ParticlePool.Instance.Clear();
        //BattleRoom.GetInstance().Clear();
        //GameObject.Destroy(GameObject.Find(""))
        ToolPool.Instance.Clear();
        TerrainManage.GetInstance().Clear();
        UIManage.GetInstance().SetUnVisvible("UI_GameEnd");
        UIManage.GetInstance().SetVisvible("UI_Search");
        MusicManager.instance.BackToMenu();
        SceneManager.LoadScene("demo1");
    }
}
