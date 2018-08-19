using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonPress : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData evendata)
    {
    //    GameObject.Find("BattleRoom/PlayerList/player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetBool("Turn", false);
        switch (this.gameObject.name)
        {
            case "Up_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.UPBRIGHT_BUTTON];
                break;
            case "Down_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.DOWNBRIGHT_BUTTON];
                break;
            case "Left_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.LEFTBRIGHT_BUTTON];
                break;
            case "Right_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.RIGHTBRIGHT_BUTTON];
                break;
            default:
                break;
        }
       
      
    }
    public void OnPointerUp(PointerEventData evendata)
    {
        //GameObject.Find("BattleRoom/PlayerList/player" + UIData.playerId.ToString() + "/Model").GetComponent<Animator>().SetBool("Turn", false);
        switch (this.gameObject.name)
        {
            case "Up_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.UPORIGINAL_BUTTON];
                break;
            case "Down_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.DOWNORIGINAL_BUTTON];
                break;
            case "Left_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.LEFTORIGINAL_BUTTON];
                break;
            case "Right_Button":
                this.GetComponent<Image>().sprite = UIData.spriteList[UIData.RIGHTORIGINSL_BUTTON];
                break;
            default:
                break;
        }
    }
}
