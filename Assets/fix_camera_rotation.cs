using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_camera_rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = Vector3.zero;
	}
}
