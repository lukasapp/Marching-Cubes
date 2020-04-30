using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TerrainGenerator mapGen = (TerrainGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.Generate();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            mapGen.Generate();
        }
    }
}
