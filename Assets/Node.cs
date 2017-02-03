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

    // Use this for initialization
    void Start()
    {

        //Invoke("CreateMesh", 0);
    }

    public void CreateMesh(GameObject babyNode, int babyNodeNumber)
    {
        Mesh mesh = new Mesh();

        Transform babyMesh = babyNodes[babyNodeNumber].transform.GetChild(0).GetChild(0);
        Transform nextBabyMesh;
        print(babyMesh);
        if (babyNodeNumber == 0)
        {
            if (nodeNumber == 0)
            {
                print("asdfasdfadsfasdf");

                nextBabyMesh = babyNodes[babyNodes.Count - 1].transform.GetChild(0).GetChild(0);
            }
            else
            {
                print("zzzzzzzzzzzzzz");
                int asdf = nodeNumber - 1;
                nextBabyMesh = Camera.main.transform;// GameObject.Find(asdf.ToString()).transform.GetChild(0).GetChild(0);
                //get first cube's biz. for very first block only!
            }
        }
        else
        {
            nextBabyMesh = babyNodes[babyNodeNumber - 1].transform.GetChild(0).GetChild(0);
        }

        newVertices = new Vector3[16];

        newVertices[0] = new Vector3(babyMesh.position.x, babyMesh.position.y + .4f, babyMesh.position.z);                  //top - mine
        newVertices[1] = new Vector3(nextBabyMesh.position.x, nextBabyMesh.position.y + 0.4f, nextBabyMesh.position.z);     //top - next

        newVertices[2] = new Vector3(babyMesh.position.x + .3f, babyMesh.position.y + .3f, babyMesh.position.z);
        newVertices[3] = new Vector3(nextBabyMesh.position.x + .3f, nextBabyMesh.position.y + .3f, nextBabyMesh.position.z);

        newVertices[4] = new Vector3(babyMesh.position.x + .4f, babyMesh.position.y, babyMesh.position.z);
        newVertices[5] = new Vector3(nextBabyMesh.position.x + .4f, nextBabyMesh.position.y, nextBabyMesh.position.z);

        newVertices[6] = new Vector3(babyMesh.position.x + .3f, babyMesh.position.y - .3f, babyMesh.position.z );
        newVertices[7] = new Vector3(nextBabyMesh.position.x + .3f, nextBabyMesh.position.y - .3f, nextBabyMesh.position.z);

        newVertices[8] = new Vector3(babyMesh.position.x, babyMesh.position.y - .4f, babyMesh.position.z);
        newVertices[9] = new Vector3(nextBabyMesh.position.x , nextBabyMesh.position.y - .4f, nextBabyMesh.position.z);

        newVertices[10] = new Vector3(babyMesh.position.x - .3f , babyMesh.position.y - .3f, babyMesh.position.z );
        newVertices[11] = new Vector3(nextBabyMesh.position.x - .3f , nextBabyMesh.position.y - .3f, nextBabyMesh.position.z);

        newVertices[12] = new Vector3(babyMesh.position.x - .4f , babyMesh.position.y, babyMesh.position.z );
        newVertices[13] = new Vector3(nextBabyMesh.position.x - .4f , nextBabyMesh.position.y, nextBabyMesh.position.z);

        newVertices[14] = new Vector3(babyMesh.position.x - .3f, babyMesh.position.y + .3f, babyMesh.position.z );
        newVertices[15] = new Vector3(nextBabyMesh.position.x - .3f , nextBabyMesh.position.y + .3f, nextBabyMesh.position.z);



        mesh.vertices = newVertices;

        /*GameObject.Find("Tube").GetComponent<Tube>().vertices = new Tube.TubeVertex[]
        {
            new Tube.TubeVertex(newVertices[0],1f,Color.white),
            new Tube.TubeVertex(newVertices[1],1f,Color.white),
            new Tube.TubeVertex(newVertices[2],1f,Color.white),
            new Tube.TubeVertex(newVertices[3],1f,Color.white),
            new Tube.TubeVertex(newVertices[4],1f,Color.white),
            new Tube.TubeVertex(newVertices[5],1f,Color.white),
            new Tube.TubeVertex(newVertices[6],1f,Color.white),
            new Tube.TubeVertex(newVertices[7],1f,Color.white),
            new Tube.TubeVertex(newVertices[8],1f,Color.white),
            new Tube.TubeVertex(newVertices[9],1f,Color.white),
            new Tube.TubeVertex(newVertices[10],1f,Color.white),
            new Tube.TubeVertex(newVertices[11],1f,Color.white),
            new Tube.TubeVertex(newVertices[12],1f,Color.white),
            new Tube.TubeVertex(newVertices[13],1f,Color.white),
            new Tube.TubeVertex(newVertices[14],1f,Color.white),
            new Tube.TubeVertex(newVertices[15],1f,Color.white)

        };
         */

        for (int i = 0; i < newVertices.Length; i++)
        {
           GameObject an = Instantiate(testCube, newVertices[i], Quaternion.identity);
           
           an.transform.parent = babyMesh;
           an.name = babyMesh + " + " + nextBabyMesh;

          
        }

        //print(babyMesh.transform.position + "," + nextBabyMesh.transform.position); 


        Vector2[] uv = new Vector2[newVertices.Length];

        for (int i = 0; i < uv.Length; i++)
        {
            uv[i] = new Vector2(newVertices[i].x, newVertices[i].y);
        }

        mesh.uv = uv;


        int[] newTriangles = new int[6];

        newTriangles[0] = 0;
        newTriangles[1] = 2;
        newTriangles[2] = 1;
        newTriangles[3] = 1;
        newTriangles[4] = 2;
        newTriangles[5] = 3;

        mesh.triangles = newTriangles;

        Vector3[] normals = new Vector3[newVertices.Length];

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }



        mesh.normals = normals;


        // mf.mesh = mesh;

        /*Vector2[] newUV = new Vector2[] 
        { 
            new Vector2(babyMesh.position.x-babyNode.transform.position.x,      babyMesh.position.y+4),         //top - mine
            new Vector2(nextBabyMesh.position.x-babyNode.transform.position.x,      nextBabyMesh.position.y+4),     //top - next

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
