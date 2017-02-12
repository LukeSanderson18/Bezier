using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    bool selected;
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
    Transform prevBabyMesh;

    //

    bool running;

    public int zing;

    void Start()
    {
        //Invoke("CreateMesh", 0);

    }

    /*public void CreateMesh(GameObject babyNode, int babyNodeNumber)
    {
        Mesh mesh = new Mesh();
        
        Transform babyMesh = babyNodes[babyNodeNumber].transform.GetChild(0);
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

        newVertices = new Vector3[8];

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

        mesh.vertices = newVertices;

       
        for (int i = 0; i < newVertices.Length; i++)
        {
            GameObject an = Instantiate(testCube, (newVertices[i]), Quaternion.identity);
          an.transform.parent = babyMesh;
            
          
        }

    }
     * */

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
            //works like shit.
           // babyNodes[0].transform.GetChild(0).eulerAngles = (babyNodes[1].transform.GetChild(0).eulerAngles + prevBabyMesh.eulerAngles);
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
