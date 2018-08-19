using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAction : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Material tempres = Resources.Load("Material/blue", typeof(Material)) as Material;
        this.GetComponent<MeshRenderer>().material = tempres;
	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
}
