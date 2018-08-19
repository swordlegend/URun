using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_InSearch : MonoBehaviour {
    private GameObject TextSearch;
    private GameObject NumSearch;
  
	void Start () {
        TextSearch = this.transform.Find("text").gameObject;
        NumSearch = this.transform.Find("SearchAni/text").gameObject;
        StartCoroutine(TextAnimation());
    }
    public void SetNum(int curNum,int totalNum)
    {
        //Debug.Log(NumSearch);
        //Debug.Log(curNum.ToString()+totalNum.ToString());
        NumSearch.GetComponent<Text>().text = curNum.ToString()+"/"+totalNum.ToString();
    }
    private IEnumerator TextAnimation()
    {
        while (true)
        {
            yield return StartCoroutine(WaitSomeSeconds(1.0f));
            TextSearch.GetComponent<Text>().text = "匹配中";
            yield return null;
            yield return StartCoroutine(WaitSomeSeconds(1.0f));
            TextSearch.GetComponent<Text>().text = "匹配中.";
            yield return null;
            yield return StartCoroutine(WaitSomeSeconds(1.0f));
            TextSearch.GetComponent<Text>().text = "匹配中..";
            yield return null;
            yield return StartCoroutine(WaitSomeSeconds(1.0f));
            TextSearch.GetComponent<Text>().text = "匹配中...";
            yield return null;

        }

    }
    
   
    IEnumerator WaitSomeSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        yield return null;
    }
}
