using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using usercmd;
using HiGame;
public class UILogin : MonoBehaviour {
    private string Name;
    private string Ip;
    public GameObject IpCon;
    public GameObject NameCon;
    private void Start()
    {
        IpCon.GetComponent<InputField>().text = "192.168.212.192:8000";
    }
    public void OnLogin()
    {
        Name=NameCon.GetComponent<InputField>().text;
        Ip = IpCon.GetComponent<InputField>().text;
        if (Name != "")
        {
            StartCoroutine(WaitsomeSecondsTcp(Ip, 1.0f, Name));
        }
    }
    private IEnumerator WaitsomeSecondsTcp(string ip,float time,string userName)
    {
        yield return null;
        GameInit.GetInstance().Tcp = new TcpConnection(ip,userName);
        yield return new WaitForSeconds(time);
    }
}
