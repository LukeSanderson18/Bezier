using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{


    public GameObject testCube;

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

    public Vector3[] newVertices;
    //

    bool running;

    public int zing;

    void Start()
    {
        //Invoke("CreateMesh", 0);
    }

    public void CreateMesh(GameObject babyNode, int babyNodeNumber)
    {
        Mesh mesh = new Mesh();
        
        Transform babyMesh = babyNodes[babyNodeNumber].transform.GetChild(0);
        Transform prevBabyMesh;
        print(babyMesh);
        if (babyNodeNumber == 0)
        {
            if (nodeNumber == 0)
            {
                prevBabyMesh = Camera.main.GetComponent<Line>().list_go[Camera.main.GetComponent<Line>().list_go.Count - 1].gameObject.transform.GetChild(0);
            }
            else
            {
                prevBabyMesh = Camera.main.GetComponent<Line>().list_go[nodeNumber - 1].gameObject.transform.GetChild(0);
            }
        }
        else
        {
            prevBabyMesh = babyNodes[babyNodeNumber - 1].transform.GetChild(0);
        }

        newVertices = new Vector3[16];

        newVertices[0] = new Vector3(babyMesh.position.x, babyMesh.position.y + .8f, babyMesh.position.z);                  //top - mine
        newVertices[1] = new Vector3(babyMesh.position.x + .3f, babyMesh.position.y + .3f, babyMesh.position.z);
        newVertices[2] = new Vector3(babyMesh.position.x + .4f, babyMesh.position.y, babyMesh.position.z);
        newVertices[3] = new Vector3(babyMesh.position.x + .3f, babyMesh.position.y - .3f, babyMesh.position.z );
        newVertices[4] = new Vector3(babyMesh.position.x, babyMesh.position.y - .4f, babyMesh.position.z);
        newVertices[5] = new Vector3(babyMesh.position.x - .3f , babyMesh.position.y - .3f, babyMesh.position.z );
        newVertices[6] = new Vector3(babyMesh.position.x - .4f , babyMesh.position.y, babyMesh.position.z );
        newVertices[7] = new Vector3(babyMesh.position.x - .3f, babyMesh.position.y + .3f, babyMesh.position.z );
        //
        //
        newVertices[8] = new Vector3(prevBabyMesh.position.x, prevBabyMesh.position.y + .8f, prevBabyMesh.position.z);                  //top - mine
        newVertices[9] = new Vector3(prevBabyMesh.position.x + .3f, prevBabyMesh.position.y + .3f, prevBabyMesh.position.z);
        newVertices[10] = new Vector3(prevBabyMesh.position.x + .4f, prevBabyMesh.position.y, prevBabyMesh.position.z);
        newVertices[11] = new Vector3(prevBabyMesh.position.x + .3f, prevBabyMesh.position.y - .3f, prevBabyMesh.position.z);
        newVertices[12] = new Vector3(prevBabyMesh.position.x, prevBabyMesh.position.y - .4f, prevBabyMesh.position.z);
        newVertices[13] = new Vector3(prevBabyMesh.position.x - .3f, prevBabyMesh.position.y - .3f, prevBabyMesh.position.z);
        newVertices[14] = new Vector3(prevBabyMesh.position.x - .4f, prevBabyMesh.position.y, prevBabyMesh.position.z);
        newVertices[15] = new Vector3(prevBabyMesh.position.x - .3f, prevBabyMesh.position.y + .3f, prevBabyMesh.position.z);

        mesh.vertices = newVertices;

       // newnewVertices = new Vector3[16];
       
        for (int i = 0; i < newVertices.Length/2; i++)
        {
            GameObject an = Instantiate(testCube, (newVertices[i]), Quaternion.identity);
          an.transform.parent = babyMesh;
            
          
        }
        
        /*
        Vector2[] uv = new Vector2[newVertices.Length];

        for (int i = 0; i < uv.Length; i++)
        {
            uv[i] = new Vector2(newVertices[i].x, newVertices[i].y);
        }

        mesh.uv = uv;

        int[] newTriangles = new int[6];

        newTriangles[0] = 0;
        newTriangles[1] = 1;
        newTriangles[2] = 2;
        newTriangles[3] = 3;
        newTriangles[4] = 0;
        newTriangles[5] = 2;
        

        

       // mesh.triangles = new int[] { 0, 1, 2 };
        mesh.triangles = newTriangles;

        Vector3[] normals = new Vector3[newVertices.Length];

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }

        mesh.normals = normals;

        GameObject mf = babyNodes[babyNodeNumber].transform.GetChild(0).GetChild(0).gameObject;
        mf.AddComponent<MeshFilter>();
        mf.AddComponent<MeshRenderer>();

        mf.GetComponent<MeshFilter>().mesh = mesh;

        /*Vector2[] newUV = new Vector2[] 
        { 
            new Vector2(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y+4),         //top - mine

            new Vector2(babyMesh.position.x +3-babyNode.transform.position.x,   babyMesh.position.y+3),
            new Vector2(nextBabyMesh.position.x +3-babyNode.transform.position.x,   nextBabyMesh.position.y+3),

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
         */

        //babyNode.transform.GetChild(0).GetChild(0).Translate(-4.75f, 0, 0, Space.Self);
        /*Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }
         */

        // Set up game object with mesh;
       // babyNode.transform.GetChild(0).GetChild(0).gameObject.AddComponent(typeof(MeshRenderer));
       // MeshFilter filter = babyNode.transform.GetChild(0).GetChild(0).gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
       // filter.mesh = mesh;

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
            babyNode1.name = ("BabyNode:" + i);


        }
        for (int i = 0; i < babyNodes.Count; i++)
        {
            CreateMesh(babyNodes[i], i);
        }

        running = true;
    }

    // Update is called once per frame
    void Update()
    {

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


            for (int i = 0; i < babyNodes.Count; i++)
            {
                GetBezier(i / (float)babyNodes.Count);
                babyNodes[i].transform.position = bezierPoint;
                if (i < babyNodes.Count - 1)
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
