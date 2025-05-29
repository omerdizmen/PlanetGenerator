using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphere : MonoBehaviour
{
    public int gridSize;

    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals;
    private Color32[] cubeUV;

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Sphere";
        CreateVertices();
        CreateTriangles();
        CreateColliders();
    }

    private void CreateColliders()
    {
        gameObject.AddComponent<SphereCollider>();
    }

    private void CreateVertices()
    {
        throw new NotImplementedException();
    }

    private void CreateTriangles()
    {
        throw new NotImplementedException();
    }
}
