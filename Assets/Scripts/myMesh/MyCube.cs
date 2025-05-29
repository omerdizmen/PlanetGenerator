using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter) , typeof(MeshRenderer))]
public class MyCube : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;

    [SerializeField] int width;
    [SerializeField] int height;

    [SerializeField] float objWidth;
    [SerializeField] float objHeight;

    [SerializeField] int tileSize { get; set; }

    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "MyGrid";
        Debug.Log(Vector3.up + " <<  vector 3 up");

        Vector3 localUp = new Vector3(0f, 1f, 0f);
        Vector3 a = new Vector3(1f, 0f, 0f);

        Debug.Log(Vector3.Cross(a, localUp));
        

    }

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        float calculatedWidth =  width / objWidth;
        float calculatedHeight = height / objHeight;

        vertices = new Vector3[4 * (int)calculatedWidth * (int)calculatedHeight];
        uv = new Vector2[vertices.Length];
        triangles = new int[6 * (int)calculatedWidth * (int)calculatedHeight];

        Debug.Log(calculatedWidth + "< width--" + "height > " + calculatedHeight + "---" + vertices.Length);

        for (int x = 0, index = 0; x < calculatedWidth; x++)
        {
            for (int y = 0; y < calculatedHeight; y++, index++)
            {
                
                vertices[index * 4 + 0] = new Vector3(x * objWidth, y * objHeight);
                vertices[index * 4 + 1] = new Vector3(x * objWidth, (y + 1) * objHeight, 0);
                vertices[index * 4 + 2] = new Vector3((x + 1) * objWidth, y * objHeight, 0);
                vertices[index * 4 + 3] = new Vector3((x + 1) * objWidth, (y + 1) * objHeight, 0);

                uv[index * 4 + 0] = new Vector2(x * objWidth, y * objHeight);
                uv[index * 4 + 1] = new Vector2(x * objWidth, (y + 1) * objHeight);
                uv[index * 4 + 2] = new Vector2((x + 1) * objWidth, y * objHeight);
                uv[index * 4 + 3] = new Vector2((x + 1) * objWidth, (y + 1) * objHeight);

                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;

                triangles[index * 6 + 3] = index * 4 + 2;
                triangles[index * 6 + 4] = index * 4 + 1;
                triangles[index * 6 + 5] = index * 4 + 3;

                if (x > 195)
                {
                    //Debug.Log("index * 6> " + index * 6 + " index " + index);
                    //Debug.Log(triangles[index * 6 + 0] + " < triangles " + x);
                    //Debug.Log(triangles[index * 6 + 1] + " < triangles " + x);
                    //Debug.Log(triangles[index * 6 + 2] + " < triangles " + x);
                    //Debug.Log(triangles[index * 6 + 3] + " < triangles " + x);
                    //Debug.Log(triangles[index * 6 + 4] + " < triangles " + x);
                    //Debug.Log(triangles[index * 6 + 5] + " < triangles " + x);
                }

                
            }
           
        }
        

        //vertices[0] = new Vector3(0, 0);
        //vertices[1] = new Vector3(0, 1);
        //vertices[2] = new Vector3(1, 0);
        //vertices[3] = new Vector3(1, 1);

        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        //triangles[3] = 2;
        //triangles[4] = 1;
        //triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
