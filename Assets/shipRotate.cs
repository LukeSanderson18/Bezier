using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipRotate : MonoBehaviour {

    public float moveSpeed = 10f;       //speed of which it jumps to box
    public float rotSpeed = 2f;         //speed of which it rotates to box
    public GameObject mainBox;

    Quaternion offset = Quaternion.Euler(-90, 180, 0);

    // Super simple script that lerps the ship model's rotation
    // to the parent's.

	void FixedUpdate () {

        transform.position = Vector3.Lerp(transform.position, mainBox.transform.position, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, mainBox.transform.rotation * offset, Time.time * rotSpeed);
		
	}
}
