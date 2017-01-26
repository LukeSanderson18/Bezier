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
    [Range(0f, 1f)]
    public float magicFloat = 0.5f;
    //
    public Vector3 startPoint;
    public Vector3 controlPoint;
    public Vector3 endPoint;

    public Vector3 bezierPoint;

    public int noOfSegments = 10;
    public List<GameObject> babyNodes;

    //

    bool running;


	// Use this for initialization
	void Start () {

        //It takes a frame to receive data from Line class. So I started later. Sue me
        //Invoke("Start2", 0.1f);     


	}

    public void Start2()
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

        startPoint = transform.position;
        endPoint = nextGO.transform.position;   //convert next GO number to int

        controlPoint = Vector3.Lerp(startPoint, endPoint, 0.5f);
        controlPointGO = Instantiate(controlPointPrefab, controlPoint, Quaternion.identity);
        babyNodes.Clear();
        for (int i = 0; i < noOfSegments; i++)
        {
            GameObject babyNode1 = Instantiate(babyNode1prefab, transform.position, Quaternion.identity);
            babyNodes.Add(babyNode1);
        }


        running = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Start2();
        }
        if (running)
        {
            
            startPoint = transform.position;
            endPoint = nextGO.transform.position;   //convert next GO number to int
            controlPoint = controlPointGO.transform.position;

            //magicFloat = Mathf.PingPong(Time.time, 1);


            for (int i = 0; i < babyNodes.Count; i++ )
            {
                GetBezier(i/(float)babyNodes.Count);
                //print(i + "   ___ " + bezierPoint);               //testing.
                babyNodes[i].transform.position = bezierPoint;

            }




        }
		
	}

    public Vector3 GetBezier(float t)
    {
        bezierPoint.x = (1 - t) * (1 - t) * startPoint.x + 2 * (1 - t) * t * controlPoint.x + t * t * endPoint.x;
        bezierPoint.y = (1 - t) * (1 - t) * startPoint.y + 2 * (1 - t) * t * controlPoint.y + t * t * endPoint.y;
        bezierPoint.z = (1 - t) * (1 - t) * startPoint.z + 2 * (1 - t) * t * controlPoint.z + t * t * endPoint.z;

        return bezierPoint;

        //what a sexy bit of code.
    }
}
