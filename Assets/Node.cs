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

    public int zing;

	// Use this for initialization
	void Start () {

        //Invoke("CreateMesh", 0);


	}

    void CreateMesh(GameObject babyNode)
    {
        // Use the triangulator to get indices for creating triangles
        print("HIASFHAISFH");
        Vector2[] vertices2D = new Vector2[]
        {
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x,babyNode.transform.GetChild(0).GetChild(0).position.y+4),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x +3,babyNode.transform.GetChild(0).GetChild(0).position.y+3),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x+4,babyNode.transform.GetChild(0).GetChild(0).position.y),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x+3,babyNode.transform.GetChild(0).GetChild(0).position.y-3),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x,babyNode.transform.GetChild(0).GetChild(0).position.y-4),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x-3,babyNode.transform.GetChild(0).GetChild(0).position.y-3),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x-4,babyNode.transform.GetChild(0).GetChild(0).position.y),
            new Vector2(babyNode.transform.GetChild(0).GetChild(0).position.x-3,babyNode.transform.GetChild(0).GetChild(0).position.y+3),


        };
        Triangulator tr = new Triangulator(vertices2D);
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
            CreateMesh(babyNode1);
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
