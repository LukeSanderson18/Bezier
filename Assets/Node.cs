using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public GameObject babyNode1prefab;
    public GameObject babyNode2prefab;
    GameObject babyNode1;
    GameObject babyNode2;
    public float magicFloat = 0.5f;
	// Use this for initialization
	void Start () {
        GetBezier(magicFloat);
        babyNode1 = Instantiate(babyNode1prefab, transform.position, Quaternion.identity);
        babyNode2 = Instantiate(babyNode2prefab, transform.position, Quaternion.identity);s
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public Vector3 GetBezier(float t)
    {

        Vector3 point = Vector3.zero;
        point.x = 
        return t;
    }
}
