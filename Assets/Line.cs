using UnityEngine;
using System.Collections;
 using System.Collections.Generic;

public class Line : MonoBehaviour {

    public Vector3[] nodes;
    public GameObject nodePrefab;
    public List<GameObject> list_go;

    void Start()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            GameObject an = Instantiate(nodePrefab, nodes[i] ,Quaternion.identity) as GameObject;
            list_go.Add(an);
            an.GetComponent<Node>().nodeNumber = i;
            an.gameObject.name = ""+i;
        }
    }

    public void Reset()
    {
        nodes = new Vector3[]
        {
            new Vector3(1,0,0),
            new Vector3(2,0,0),
            new Vector3(3,0,0)

        };
    }

    void Update()
    {
        for (int i = 0; i < nodes.Length-1; i++)
        {
            if (i < nodes.Length)
            {
                list_go[i].GetComponent<LineRenderer>().SetPosition(1, list_go[1+i].transform.position-list_go[i].transform.position);
            }
            
        }
        for (int i = nodes.Length; i == nodes.Length; i++)
        {
            list_go[i-1].GetComponent<LineRenderer>().SetPosition(1,list_go[0].transform.position-list_go[i-1].transform.position);
           // Destroy(list_go[i-1].gameObject);
        }


    }


}
