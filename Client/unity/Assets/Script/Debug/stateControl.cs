using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateControl : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("x", 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("x", 2);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("x", 1);
        }
    }
}
