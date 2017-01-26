using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int nodeNumber;
    public GameObject babyNode1prefab;
    public GameObject babyNode2prefab;
    GameObject babyNode1;
    GameObject babyNode2;
    public float magicFloat = 0.5f;
	// Use this for initialization
	void Start () {
        

        GetBezier(magicFloat);
        babyNode1 = Instantiate(babyNode1prefab, transform.position, Quaternion.identity);
        babyNode2 = Instantiate(babyNode2prefab, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public Vector3 GetBezier(float t)
    {

        Vector3 startPoint = transform.position;
        Vector3 controlPoint;
        Vector3 endPoint = GameObject.Find(""+nodeNumber+1).transform.position;
        
       // point.x = (1-t) * (1-t) * point.x


       //   x = (1 - t) * (1 - t) * p[0].x + 2 * (1 - t) * t * p[1].x + t * t * p[2].x;
       // y = (1 - t) * (1 - t) * p[0].y + 2 * (1 - t) * t * p[1].y + t * t * p[2].y;
        return t;
    }
}
