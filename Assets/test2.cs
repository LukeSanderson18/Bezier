using UnityEngine;

public class test2 : MonoBehaviour
{

    private Vector3[] newVertices = new Vector3[4];
    public Vector2[] newUV;
    private int[] newTriangles = new int[6];

    void Meh()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        // Do some calculations...
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }

    public void Create(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        newVertices[0] = a;
        newVertices[1] = b;
        newVertices[2] = c;
        newVertices[3] = d;

        mesh.vertices = newVertices;

        newTriangles[0] = 0;
        newTriangles[1] = 1;
        newTriangles[2] = 2;
        newTriangles[3] = 3;
        newTriangles[4] = 0;
        newTriangles[5] = 2;

        mesh.triangles = newTriangles;

    }
}