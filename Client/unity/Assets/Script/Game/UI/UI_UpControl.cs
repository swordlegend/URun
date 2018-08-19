using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using usercmd;
public class UI_UpControl : MonoBehaviour {

    private GameObject Time;
    private GameObject EnergyNum;
    public colorType currentType;
    private void Start()
    {
        Time = this.transform.Find("Time").gameObject;
        EnergyNum = this.transform.Find("UI_EnergyNum").gameObject;
        currentType = colorType.origin;
    }

    public void setEnergy(colorType color,int num)
    {
        currentType = color;
        UpdateEnergy(num);
    }
    private void UpdateEnergy(int percent)
    {
        if (percent > 100)
        {
            Debug.LogError("percent 超出100");
        }
        int num = percent / 4;
        if (num > 0)
        {
            SetColor(num);
        }
    }
    private void SetColor(int num)
    {

        for (int i = 1; i <= num; i++)
        {
            switch (currentType)
            {
                case colorType.red:
                    EnergyNum.transform.Find("Cell" + i.ToString()).gameObject.GetComponent<Image>().sprite = UIData.spriteList[UIData.RED_ENERGY];
                    break;
                case colorType.yellow:
                    EnergyNum.transform.Find("Cell" + i.ToString()).gameObject.GetComponent<Image>().sprite = UIData.spriteList[UIData.YELLOW_ENERGY];
                    break;
                case colorType.blue:
                    EnergyNum.transform.Find("Cell" + i.ToString()).gameObject.GetComponent<Image>().sprite = UIData.spriteList[UIData.BLUE_ENERGY];
                    break;
                default:
                    break;     
            }
        }
        for (int i = num + 1; i <= 25; i++)
        {
            EnergyNum.transform.Find("Cell" + i.ToString()).gameObject.GetComponent<Image>().sprite = UIData.spriteList[UIData.ORIGINAL_ENERGY];
        }
    }
    public void UpdateTime(int minute ,int second)
    {
        if (second < 10)
        {
            Time.GetComponent<Text>().text = "0" + minute.ToString() + ":0" + second.ToString();
        }
        else
        {
            Time.GetComponent<Text>().text = "0" + minute.ToString() + ":" + second.ToString();
        }
    }
    public void showTips(string data,float time)
    {
      StartCoroutine(WaitSomeSeconds(time, data));
    }
    IEnumerator WaitSomeSeconds(float time, string data)
    {
        this.transform.Find("TipsBg").gameObject.SetActive(true);
        this.transform.Find("TipsBg/Text").GetComponent<Text>().text = data;
        yield return new WaitForSeconds(time);
        yield return null;
        this.transform.Find("TipsBg").gameObject.SetActive(false);
    }
}
