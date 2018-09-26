using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextName : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
        //transform.Rotate(0, 180, 0);
	}
}
