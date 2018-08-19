using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using usercmd;

public class Cell:FlagInMiniMap{

    public  colorType color;
    public Cell(GameObject go,GameObject _flagInMiniMap)
    {
        RootObj = new GameObject("CellRoot");
        GameObject = go;
        flagInMiniMap = _flagInMiniMap;
        GameObject.transform.SetParent(RootObj.transform);
        flagInMiniMap.transform.SetParent(RootObj.transform);
        flagInMiniMap.transform.localPosition = new Vector3(flagInMiniMap.transform.localPosition.x, 0.0f, flagInMiniMap.transform.localPosition.z);
    }
    public void ActionAnimation()
    {
        GameWorld.Instance.startCoroutine(Animation());
    }
    private IEnumerator Animation()
    {
        var posY = this.RootObj.transform.position.y/25.0f;
        for (int i = 0; i < 25; i++)
        {
            this.RootObj.transform.position += new Vector3(0.0f, -posY, 0.0f);
            yield return null;
        }

    }
    public void setColor(colorType _color)
    {
        color = _color;
        //Debug.Log("变色" + color);
        //Debug.Log(Time.frameCount);
        Render();
    }
    private void Render()
    {
        switch (color)
        {
            case colorType.origin:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[0];
                this.flagInMiniMap.GetComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.ORIGINAL_CELL];
                break;
            case colorType.red:
                //GameObject.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1.0f, 0.0f, 0.0f, 1.0f);
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[1];
                this.flagInMiniMap.GetComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.RED_CELL];
                break;
            case colorType.yellow:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[2];
                this.flagInMiniMap.GetComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.YELLOW_CELL];
                break;
            case colorType.blue:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[3];
                this.flagInMiniMap.GetComponent<SpriteRenderer>().sprite = UIData.spriteList[UIData.BLUE_CELL];
                break;
            default:
                break;
        }

    }
    public void RendTool(itemType item)
    {
        switch (color)
        {
            case colorType.origin:
                switch (item)
                {
                    case itemType.virus:
                        //GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.TOOLVIRUSORIGINAL_MATERIAL];
                        break;
                        //case itemType.dyeing:
                        //    GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.TOOLVIRUS_RED];
                        //    break;
                        //case itemType.unknown:
                        //    GameObject                    
                }
                break;
            case colorType.red:
                switch (item)
                {
                    case itemType.virus:
                        GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.TOOLVIRUSRED_MATERIAL];
                        break;
                        //case itemType.unknown:
                        //    GameObject                    
                }
                break;
            case colorType.yellow:
                switch (item)
                {
                    case itemType.virus:
                        GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.TOOLVIRUSYELLOW_MATERIAL];
                        break;
                        //case itemType.unknown:
                        //    GameObject                    
                }
                break;
            case colorType.blue:
                switch (item)
                {
                    case itemType.virus:
                        GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.TOOLVIRUSBLUE_MATERIAL];
                        break;
                        //case itemType.unknown:
                        //    GameObject                    
                }
                break;
        }
    }
    public void DesTroyTool()
    {
        switch (color)
        {
            case colorType.red:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.CELLRED_MATERIAL];
                break;
            case colorType.yellow:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.CELLYELLOW_MATERIAL];
                break;
             case colorType.blue:
                GameObject.GetComponent<MeshRenderer>().material = UIData.materialList[UIData.CELLBLUE_MATERIAL];
                break;

        }
    }
    public void BrightSelf()
    {
        //Debug.Log("Bright");
      
       this.GameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1.5f, 1.5f, 1.5f));
            
      
        
    }
    public void DarkSelf()
    {
        this.GameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.6f, 0.6f, 0.6f));
    }
}
