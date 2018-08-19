using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Go : MonoBehaviour {
    public GameObject image;
	// Use this for initialization
	void Start () {
       
	}
    public  IEnumerator StartTimeWait()
    {

        UIManage.GetInstance().GetUI("UI_Keyboard").GetComponent<UI_Keyboard>().DisableMove();
        UIManage.GetInstance().SetVisvible("UI_Go");
        image.GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEGO_THREE];
        yield return WaitSomeSeconds(1.0f);
        image.GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEGO_TWO];
        yield return WaitSomeSeconds(1.0f);
        image.GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEGO_ONE];
        yield return WaitSomeSeconds(1.0f);
        image.GetComponent<Image>().sprite = UIData.spriteList[UIData.GAMEGO_GO];
        yield return WaitSomeSeconds(1.0f);
        UIManage.GetInstance().GetUI("UI_Keyboard").GetComponent<UI_Keyboard>().EnableMove();
        UIManage.GetInstance().SetUnVisvible("UI_Go");
    }
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator WaitSomeSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        yield return null;
    }
}
