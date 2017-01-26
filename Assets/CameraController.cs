using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + 10, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x - 10, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        //
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y+10, transform.eulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y-10, transform.eulerAngles.z);
        }
		
	}
}
