using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;
public class Player : ObjectBase
{
    public string name;
    public GameObject flagInMiniMap;
    public colorType color;
    public Player(GameObject go, GameObject _flagInMiniMap, colorType _color)
    {
        GameObject = go;
        //switch (_color)
        //{
        //    //case colorType.red:
        //    //    GameObject.tag = "red";
        //    //    break;

        //    //case colorType.blue:
        //    //    GameObject.tag = "blue";
        //    //    break;
        //    //case colorType.yellow:
        //    //    Debug.Log("yellow Player tag be set");
        //    //    GameObject.tag = "y";
        //    //    break;
        //    //default:
        //    //    break;
        //    case colorType.yellow:
        //        RootObj.tag = "yellow";
        //        break;
        //    default:
        //        break;
        //}
        RootObj = new GameObject("PlayerRoot");
        GameObject.transform.SetParent(RootObj.transform);
        flagInMiniMap = _flagInMiniMap;
        flagInMiniMap.transform.SetParent(RootObj.transform);
        flagInMiniMap.transform.localPosition = new Vector3(0.0f, 5.0f, 0.0f);
        color = _color;
    }
    public void AddToSelf(ObjectBase obj)
    {
       Transform EquipmentList = RootObj.transform.Find("EquipmentList");
        if (EquipmentList == null)
        {
            UnityEngine.GameObject temp = new GameObject("EquipmentList");
            temp.transform.SetParent(RootObj.transform);
            temp.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            EquipmentList = temp.transform;
        }
        obj.SetParent(EquipmentList);
        obj.RootObj.transform.localPosition = Vector3.zero;
    }

    public void UpdatePosition(float _x, float _y, float _z)
    {
        RootObj.transform.position = new Vector3(_x, _y, _z);
        //if (this.RootObj.transform.position.x != _x && this.RootObj.transform.position.z != _z)
        //{
        //    this.GameObject.GetComponent<Animator>().SetBool("Turn", true);
        //}
        //else {
        //    this.GameObject.GetComponent<Animator>().SetBool("Turn", false);
        //}
    }
}
  
//public class Virus 