using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using usercmd;
public class UI_Energy : MonoBehaviour {
    public void UpdatePercent(int percent)
    {
        if (percent > 100)
        {
            Debug.LogError("percent 超出100");
        }
        this.transform.Find("percent").GetComponent<Text>().text = percent.ToString() + "%";
        this.transform.Find("Slider").GetComponent<Slider>().value = percent;
    }
    private colorType color;
    public colorType ColorType {
        get { return color; }
    }
    public void setEnergyColor(colorType _color)
    {
        color = _color;
        switch (_color)
        {
            case colorType.red:
                this.transform.Find("Slider/Fill").GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case colorType.yellow:                
                this.transform.Find("Slider/Fill").GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
                break;
            case colorType.blue:
                this.transform.Find("Slider/Fill").GetComponent<Image>().color = new Color(0.0f, 0.0f, 1.0f);
                break;
            default:
                break;

        }
       
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
