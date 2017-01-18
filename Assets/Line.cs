using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

    public Vector3[] nodes;
    public GameObject nodePrefab;

    void Start()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            Instantiate(nodePrefab, nodes[i] ,Quaternion.identity);
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

    }


}
