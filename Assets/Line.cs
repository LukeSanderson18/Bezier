using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour
{

    public List<Vector3> nodes;
    public GameObject nodePrefab;
    public List<GameObject> list_go;
    public List<GameObject> list_babyNodes;


    int totalNodes;

    void Start()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            GameObject an = Instantiate(nodePrefab, nodes[i], Quaternion.identity) as GameObject;
            list_go.Add(an);
            an.GetComponent<Node>().nodeNumber = i;
            an.gameObject.name = "" + i;
            totalNodes++;
        }
        Add();
    }

    /* public void Reset()
     {
         nodes = new Vector3[]
         {
             new Vector3(1,0,0),
             new Vector3(2,0,0),
             new Vector3(3,0,0)

         };
     }
     */

    void Add()
    {

        list_go[list_go.Count - 1].GetComponent<Node>().lastNode = false;
        GameObject an = Instantiate(nodePrefab, new Vector3(7.916822f,0,-3.654793f), Quaternion.identity) as GameObject;
        list_go.Add(an);
        nodes.Add(an.transform.position);
        
        an.GetComponent<Node>().nodeNumber = totalNodes;
        an.GetComponent<Node>().lastNode = true;
        int tN = totalNodes;
        an.gameObject.name = "" + tN;

        list_go[list_go.Count - 2].GetComponent<Node>().nextGO = list_go[list_go.Count - 1];

       // vec3s.Clear();
        //first destroy all baby nodes...
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Node");
       
        for (var i = 0; i < gos.Length; i++)
        {
            if (gos[i].transform.parent != null)
            {
                Destroy(gos[i].transform.parent.gameObject);
            }
            Destroy(gos[i]);
        }

        //then we start it's start function again!
        for (int i = 0; i < list_go.Count; i++)
        {
            list_go[i].GetComponent<Node>().Start2();
            //list_go[i].GetComponent<Node>().controlPoint = vec3s[i];
        }



        
         
    }

    void GenTube()
    {
        TubeRenderer.TubeVertex[] toot = new TubeRenderer.TubeVertex[list_babyNodes.Count];

        for (int i = 0; i < list_babyNodes.Count; i++)
        {
            
                toot[i] = new TubeRenderer.TubeVertex(list_babyNodes[i].transform.position, 0.6f, Color.white);
            
            
        }
        GameObject.Find("Tube").GetComponent<TubeRenderer>().vertices = toot;

    }

    void Subtract()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            totalNodes++;
            Add();
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            totalNodes--;

            Subtract();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("PRESSED");
            list_babyNodes.AddRange(GameObject.FindGameObjectsWithTag("babyNode"));
            GameObject.Find("Tube").GetComponent<TubeRenderer>().vertices = new TubeRenderer.TubeVertex[list_babyNodes.Count];

            Invoke("GenTube", 0.5f);
        }
        //
        //LINE RENDERER MALARKEY
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            if (i < nodes.Count)
            {
                list_go[i].GetComponent<LineRenderer>().SetPosition(1, list_go[1 + i].transform.position - list_go[i].transform.position);
            }

        }
        for (int i = nodes.Count; i == nodes.Count; i++)
        {
            list_go[i - 1].GetComponent<LineRenderer>().SetPosition(1, list_go[0].transform.position - list_go[i - 1].transform.position);
            list_go[i - 1].GetComponent<Node>().lastNode = true;
        }
        //
        //
    }
}
