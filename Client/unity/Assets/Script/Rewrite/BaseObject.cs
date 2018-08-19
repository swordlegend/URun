using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//封装所有动态生成的Object，提供对象池支持技术
namespace Object
{
    public interface DisposeInterface {

        void disPose();
    }
    public class BaseObject:DisposeInterface{
        private GameObject _modelObj;
        private GameObject _rootObj;
        private GameObject _childrenList;

        public void disPose()
        {
            

        }
        public void disPose(float time)
        {

        }
        public void setPosition(Vector3 pos)
        {
            _rootObj.transform.position = pos;
        }
        public void setPosition(float x, float y, float z)
        {
            _rootObj.transform.position = new Vector3(x, y, z);
        }
        
        

}

}