using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {      
            this.transform.position += Vector3.back * Time.deltaTime * 1.0f;       		
	}
}
