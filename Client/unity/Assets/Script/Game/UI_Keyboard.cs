using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiGame;
using usercmd;
using UnityEngine.UI;
public class UI_Keyboard : MonoBehaviour {
    public GameObject battleRoom;
    private GameObject Myplayer;
    private float speed = UIData.PlayerSpeed;
    private Vector3 dir=Vector3.forward;
    private bool isDizzy=false;
    private bool isStop = false;
    private int frameNetwork = 1;
    private int preRow =0;
    private int preCol = 0;
    //private moveType dirType = moveType.idle;
    //Update is called once per frame

    private Vector3 GetInnerTerrain(Vector3 curPos)
    {     
        var rightTop= TerrainManage.GetInstance().cellList[TerrainManage.GetInstance()._edgeNum - 1][TerrainManage.GetInstance()._edgeNum - 1].RootObj.transform.position;
        var leftBottom= TerrainManage.GetInstance().cellList[0][0].RootObj.transform.position;
        var leftX = leftBottom.x;
        var rightX = rightTop.x;
        var bottomZ = leftBottom.z;
        var topZ = rightTop.z;
        if (curPos.z > topZ)
        {
            curPos.z = topZ;
        }
        if (curPos.z < bottomZ)
        {
            curPos.z = bottomZ;
        }
        if (curPos.x > rightX)
        {
            curPos.x = rightX;
        }
        if (curPos.x < leftX)
        {
            curPos.x = leftX;
        }
        return curPos;
    }

    void Update () {
        frameNetwork--;
        if (!isStop)
        {
            if (battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString()) != null)
            {
                Myplayer = battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString()).gameObject;
                MoveC2SMsg msg = new MoveC2SMsg();

                Myplayer.transform.position += speed * Time.deltaTime * dir;

                Myplayer.transform.position = GetInnerTerrain(Myplayer.transform.position);
                msg.playerId = UIData.playerId;

                msg.posX = Myplayer.transform.position.x;
                msg.posY = Myplayer.transform.position.y;
                msg.posZ = Myplayer.transform.position.z;
                //msg.mType = dirType;
                //Debug.Log("Move Tell");
                int row = (int)(Myplayer.transform.position.z / 1.0f +0.5);
                int col = (int)(Myplayer.transform.position.x / 1.0f+0.5f);
                if (row != preRow || col != preCol)
                {
                    TerrainManage.GetInstance().cellList[row][col].setColor(BattleRoom.GetInstance().playerList[UIData.playerId].color);
                    TerrainManage.GetInstance().cellList[row][col].ActionAnimation();
                    preRow = row;
                    preCol = col;
                }
                if (frameNetwork < 0)
                {
                    MsgHandler.Send((int)DemoTypeCmd.MoveReq, msg);
                    frameNetwork = 2;
                }
                }
        }
    }
    public void ClickUp()
    {
        //Myplayer.transform.Find("Model").GetComponent<Animator>().SetBool("Turn", true);
        if (isDizzy)
        {
            dir = Vector3.back;
        }
        else {
            dir = Vector3.forward;
        }
        //dirType = moveType.idle;
        //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 0);
    }
    public void ClickDown()
    {
        //Myplayer.transform.Find("Model").GetComponent<Animator>().SetBool("Turn", true);
        if (isDizzy)
        {
            dir = Vector3.forward;
        }
        else
        {
            dir = Vector3.back;
        }
        //dirType = moveType.idle;
        //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 0);

    }
    public void ClickLeft()
    {
        //Myplayer.transform.Find("Model").GetComponent<Animator>().SetBool("Turn", true);
        if (isDizzy)
        {
            //dirType = moveType.right;
            dir = Vector3.right;
            //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 2);
        }
        else
        {
            //dirType = moveType.left;
            dir = Vector3.left;
            //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 1);
        }
     

    }
    public void ClickRight()
    {
        //Myplayer.transform.Find("Model").GetComponent<Animator>().SetBool("Turn", true);
        if (isDizzy)
        {
            //dirType = moveType.left;
            dir = Vector3.left;
            //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 1);
        }
        else
        {
            //dirType = moveType.right;
            dir = Vector3.right;
            //battleRoom.transform.Find("PlayerList/" + "player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetInteger("x", 2);
        }
       

    }
    public void DisableMove(int time)
    {
        Debug.Log("DisableMove   UIKEY FUNC");
        speed = 0.0f;
        StartCoroutine(WaitSomeSeconds(time));
      
    }
    public void Dizzy(float time)
    {
        Debug.Log("Dizzy inner");
        dir =-dir;
        StartCoroutine(dizzyForTime(time));
    }
    IEnumerator dizzyForTime(float time)
    {
        isDizzy = true;
        yield return new WaitForSeconds(time);
        isDizzy = false;
        yield return null;
    }
    IEnumerator WaitSomeSeconds(float time)
    {
        yield return new WaitForSeconds(time);
         speed = UIData.PlayerSpeed;     
        yield return null;
    }
    public void DisableMove()
    {
        isStop = true;
    }
    public void EnableMove()
    {
        isStop = false;
    }
    public void SpeedUp(int speedNum, float time)
    {
        StartCoroutine(WaitSomeSecondsForSpeedChange(speedNum,time));
    }
    IEnumerator WaitSomeSecondsForSpeedChange(int speedNum, float time)
    {
        float value = (float)speedNum / 100.0f;
        speed *= value;
        yield return new WaitForSeconds(time);
        speed = UIData.PlayerSpeed;
    }
}
