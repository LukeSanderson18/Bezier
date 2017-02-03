﻿using System.Collections;
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

    public int zing;

	// Use this for initialization
	void Start () {

        //Invoke("CreateMesh", 0);


	}

    void CreateMesh(GameObject babyNode, int babyNodeNumber)
    {
        // Use the triangulator to get indices for creating triangles
        print("HIASFHAISFH");
        //test octagon;
        Transform babyMesh = babyNodes[babyNodeNumber].transform.GetChild(0).GetChild(0);
        Transform nextBabyMesh;
        if (babyNodeNumber == 0)
        {
            int asdf = nodeNumber-1;
            if (nodeNumber == 0)
            {
                nextBabyMesh = babyNodes[babyNodes.Count - 1].transform;
            }
            else
            {
                nextBabyMesh = GameObject.Find(asdf.ToString()).transform;
            }
        }
        else
        {
            nextBabyMesh = babyNodes[babyNodeNumber - 1].transform.GetChild(0).GetChild(0);
        }
        
        /*Vector2[] vertices2D1 = new Vector2[]
        {
            new Vector2(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y+4),
            new Vector2(babyMesh.position.x +3-babyNode.transform.position.x,   babyMesh.position.y+3),
            new Vector2(babyMesh.position.x+4-babyNode.transform.position.x,    babyMesh.position.y),
            new Vector2(babyMesh.position.x+3-babyNode.transform.position.x,    babyMesh.position.y-3),
            new Vector2(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y-4),
            new Vector2(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y-3),
            new Vector2(babyMesh.position.x-4-babyNode.transform.position.x,    babyMesh.position.y),
            new Vector2(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y+3), 
        };
         */
         

        Vector3[] newVertices = new Vector3[]
        {
            new Vector3(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y+4,babyMesh.position.z),         //top - mine
            new Vector3(nextBabyMesh.position.x-babyNode.transform.position.x,      nextBabyMesh.position.y+4,nextBabyMesh.position.z),     //top - next

            new Vector3(babyMesh.position.x +3-babyNode.transform.position.x,   babyMesh.position.y+3,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x +3-babyNode.transform.position.x,   nextBabyMesh.position.y+3,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x+4-babyNode.transform.position.x,    babyMesh.position.y,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x+4-babyNode.transform.position.x,    nextBabyMesh.position.y,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x+3-babyNode.transform.position.x,    babyMesh.position.y-3,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x+3-babyNode.transform.position.x,    nextBabyMesh.position.y-3,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y-4,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x-babyNode.transform.position.x,      nextBabyMesh.position.y-4,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y-3,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x-3-babyNode.transform.position.x,    nextBabyMesh.position.y-3,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x-4-babyNode.transform.position.x,    babyMesh.position.y,babyMesh.position.z),
            new Vector3(nextBabyMesh.position.x-4-babyNode.transform.position.x,    nextBabyMesh.position.y,nextBabyMesh.position.z),

            new Vector3(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y+3,babyMesh.position.z), 
            new Vector3(nextBabyMesh.position.x-3-babyNode.transform.position.x,    nextBabyMesh.position.y+3,nextBabyMesh.position.z), 


        };

        Vector2[] newUV = new Vector2[] 
        { 
            new Vector2(babyMesh.position.x+4-babyNode.transform.position.x,    babyMesh.position.y),
            new Vector2(nextBabyMesh.position.x+4-babyNode.transform.position.x,    nextBabyMesh.position.y),

            new Vector2(babyMesh.position.x+3-babyNode.transform.position.x,    babyMesh.position.y-3),
            new Vector2(nextBabyMesh.position.x+3-babyNode.transform.position.x,    nextBabyMesh.position.y-3),

            new Vector2(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y-4),
            new Vector2(nextBabyMesh.position.x-babyNode.transform.position.x,      nextBabyMesh.position.y-4),

            new Vector2(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y-3),
            new Vector2(nextBabyMesh.position.x-3-babyNode.transform.position.x,    nextBabyMesh.position.y-3),

            new Vector2(babyMesh.position.x-4-babyNode.transform.position.x,    babyMesh.position.y),
            new Vector2(nextBabyMesh.position.x-4-babyNode.transform.position.x,    nextBabyMesh.position.y),

            new Vector2(babyMesh.position.x-3-babyNode.transform.position.x,    babyMesh.position.y+3), 
            new Vector2(nextBabyMesh.position.x-3-babyNode.transform.position.x,    nextBabyMesh.position.y+3), 

        };

        int[] newTriangles = new int[] { 0, 1, 2 };

         Mesh mesh = new Mesh();
         Camera.main.GetComponent<MeshFilter>().mesh = mesh;
         mesh.vertices = newVertices;
         mesh.uv = newUV;
         mesh.triangles = newTriangles;
        
        //babyNode.transform.GetChild(0).GetChild(0).Translate(-4.75f, 0, 0, Space.Self);
        /*Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        babyNode.transform.GetChild(0).GetChild(0).gameObject.AddComponent(typeof(MeshRenderer));
        MeshFilter filter = babyNode.transform.GetChild(0).GetChild(0).gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        filter.mesh = msh;
         * 
         * */
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
            CreateMesh(babyNode1,i);
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
                babyNodes[i].transform.position = bezierPoint;
                if (i < babyNodes.Count-1)
                {
                    babyNodes[i].transform.GetChild(0).LookAt(babyNodes[i + 1].transform.position);
                }
                else
                {
                    babyNodes[i].transform.GetChild(0).LookAt(nextGO.transform.position);
                }

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
