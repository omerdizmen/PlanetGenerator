using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 10;
    MeshFilter[] meshFilters;
    TerrainFace[] dancingCubes;
    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;
    public bool autoUpdate = true;

    public enum FaceRenderMask { All, Top, Bottom, Left, Right,Front,Back };
    public FaceRenderMask faceRenderMask;

    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colorSettingsFoldout;


    ShapeGenerator shapeGenerator = new ShapeGenerator();
    ColorGenerator colorGenerator = new ColorGenerator();

    Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };


    void Initialiaze()
    {
        shapeGenerator.UpdateSettings(shapeSettings);
        colorGenerator.UpdateSettings(colorSettings);
        //shapeGenerator = new ShapeGenerator(shapeSettings);
        //colorGenerator = new ColorGenerator(colorSettings);

        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        

        dancingCubes = new TerrainFace[6];

        for (int i = 0; i < directions.Length; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject mesh = new GameObject("mesh");
                mesh.transform.parent = transform;

                mesh.AddComponent<MeshRenderer>();
                meshFilters[i] = mesh.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colorSettings.planetMaterial;
            
            dancingCubes[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh,resolution,directions[i]);
            bool renderFace = faceRenderMask == FaceRenderMask.All || (int)faceRenderMask - 1 == i;
            meshFilters[i].gameObject.SetActive(renderFace);
        }

    }

    public void GeneratePlanet()
    {
        Initialiaze();
        GenerateMesh();
        GenereateColors();
    }

    public void OnShapeSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialiaze();
            GenerateMesh();
        }
    }

    public void OnColorSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialiaze();
            GenereateColors();
        }
    }

    void GenerateMesh()
    {
        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i].gameObject.activeSelf)
            {
                dancingCubes[i].CreateMesh();
            }
        }
        colorGenerator.UpdateElevation(shapeGenerator.elevationMinmax);
    }

    
    void GenereateColors()
    {
        //foreach (MeshFilter mesh in meshFilters)
        //{
        //    mesh.GetComponent<MeshRenderer>().sharedMaterial.color = colorSettings.planetColor;
        //}

        colorGenerator.UpdateColors();
    }
}
