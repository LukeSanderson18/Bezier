using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public bool lastNode;
    public int nodeNumber;
    public GameObject nextGO;
    int nextGO_int;
    GameObject controlPointGO;
    public GameObject controlPointPrefab;
    public GameObject babyNode1prefab;
    GameObject babyNode1;
    [Range(0f, 1f)]
    public float magicFloat = 0.5f;
    //
    Vector3 startPoint;
    Vector3 controlPoint;
    public Vector3 endPoint;

    public Vector3 bezierPoint;


	// Use this for initialization
	void Start () {

        Invoke("Ham", 0.1f);      
        controlPoint = Vector3.Lerp(startPoint, endPoint, 0.5f);             // start with control point exactly inbetween them.
        controlPointGO = Instantiate(controlPointPrefab, controlPoint, Quaternion.identity);
        babyNode1 = Instantiate(babyNode1prefab, transform.position, Quaternion.identity);

	}

    void Ham()
    {
        if (!lastNode)
        {
            nextGO_int = nodeNumber + 1;
            nextGO = GameObject.Find(nextGO_int.ToString());
        }
        else
        {
            nextGO = GameObject.Find("0");
        }
    }
	
	// Update is called once per frame
	void Update () {

        startPoint = transform.position;
        int nextGO_int = nodeNumber;
        endPoint = nextGO.transform.position;   //convert next GO number to int
        controlPoint = controlPointGO.transform.position;
        magicFloat = Mathf.PingPong(Time.time, 1);
        GetBezier(magicFloat);


        babyNode1.transform.position = bezierPoint;
		
	}

    public Vector3 GetBezier(float t)
    {

       // point.x = (1-t) * (1-t) * point.x
        
        bezierPoint.x = (1 - t) * (1 - t) * startPoint.x + 2 * (1 - t) * t * controlPoint.x + t * t * endPoint.x;
        bezierPoint.y = (1 - t) * (1 - t) * startPoint.y + 2 * (1 - t) * t * controlPoint.y + t * t * endPoint.y;
        bezierPoint.z = (1 - t) * (1 - t) * startPoint.z + 2 * (1 - t) * t * controlPoint.z + t * t * endPoint.z;

       
        return bezierPoint;
    }
}
