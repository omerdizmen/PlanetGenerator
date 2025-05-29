using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Test");
        Mesh mesh = new Mesh();

        int width = 10;
        int height = 10;

        Vector3[] vertices = new Vector3[4 * (width * height)];
        Vector2[] uv = new Vector2[4 * (width * height)];
        int[] triangles = new int[6 * (width * height)];

        int objWidth = 10;
        int objHeight = 10;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * height + y;

                vertices[index * 4 + 0] = new Vector3(objWidth * x, objHeight * y);
                vertices[index * 4 + 1] = new Vector3(objWidth * x, objHeight * (y + 1));
                vertices[index * 4 + 2] = new Vector3(objWidth * (x + 1), objHeight * (y+1));
                vertices[index * 4 + 3] = new Vector3(objWidth * (x + 1), objHeight * y);

                uv[index * 4 + 0] = new Vector2(objWidth * x, objHeight * y);
                uv[index * 4 + 1] = new Vector2(objWidth * x, objHeight * (y + 1));
                uv[index * 4 + 2] = new Vector2(objWidth * (x + 1), objHeight * (y + 1));
                uv[index * 4 + 3] = new Vector2(objWidth * (x + 1), objHeight * y);

                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;

                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;

            }            
        }        

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }


}
