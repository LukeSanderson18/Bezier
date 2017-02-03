using UnityEngine;
using System.Collections;
 using System.Collections.Generic;

public class Line : MonoBehaviour {

    public List<Vector3> nodes;
    public GameObject nodePrefab;
    public List<GameObject> list_go;

    int totalNodes;

    void Start()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            GameObject an = Instantiate(nodePrefab, nodes[i] ,Quaternion.identity) as GameObject;
            list_go.Add(an);
            an.GetComponent<Node>().nodeNumber = i;
            an.gameObject.name = ""+i;
            totalNodes++;
        }
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
        GameObject an = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        list_go.Add(an);
        nodes.Add(an.transform.position);
        
        an.GetComponent<Node>().nodeNumber = totalNodes;
        an.GetComponent<Node>().lastNode = true;
        int tN = totalNodes;
        an.gameObject.name = "" + tN;

        list_go[list_go.Count - 2].GetComponent<Node>().nextGO = list_go[list_go.Count - 1];
      
        //first destroy all baby nodes...
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Node");

        for (var i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }

        //then we start it's start function again!
        for (int i = 0; i < list_go.Count; i++)
        {
            list_go[i].GetComponent<Node>().Start2();
        }

        GameObject.Find("Tube").GetComponent<Tube>().vertices = new Tube.TubeVertex[]
        {
            new Tube.TubeVertex(nodes[0],1f,Color.white),
            new Tube.TubeVertex(nodes[1],1f,Color.white),
            new Tube.TubeVertex(nodes[2],1f,Color.white),
            new Tube.TubeVertex(nodes[3],1f,Color.white),
            new Tube.TubeVertex(nodes[4],1f,Color.white),
                        new Tube.TubeVertex(nodes[5],1f,Color.white),
                                    new Tube.TubeVertex(nodes[0],1f,Color.white),



        };
    }

    void Subtract()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Add();
            totalNodes++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Subtract();
        }
        //
        //LINE RENDERER MALARKEY
        for (int i = 0; i < nodes.Count-1; i++)
        {
            if (i < nodes.Count)
            {
                list_go[i].GetComponent<LineRenderer>().SetPosition(1, list_go[1+i].transform.position-list_go[i].transform.position);
            }
            
        }
        for (int i = nodes.Count; i == nodes.Count; i++)
        {
            list_go[i-1].GetComponent<LineRenderer>().SetPosition(1,list_go[0].transform.position-list_go[i-1].transform.position);
            list_go[i - 1].GetComponent<Node>().lastNode = true;
        }
        //
        //
    }
}
