using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ChunkGenerator))]
public class ChunkGenerationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ChunkGenerator chunkGen = (ChunkGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            chunkGen.Generate();
        }

        if (GUILayout.Button("Add Chunk: X"))
            chunkGen.CreateChunk(chunkGen.sizeX++, chunkGen.sizeY-1, chunkGen.sizeZ-1);
        if (GUILayout.Button("Add Chunk: Y"))
            chunkGen.CreateChunk(chunkGen.sizeX-1, chunkGen.sizeY++, chunkGen.sizeZ-1);
        if (GUILayout.Button("Add Chunk: Z"))
            chunkGen.CreateChunk(chunkGen.sizeX-1, chunkGen.sizeY-1, chunkGen.sizeZ++);
    }
}
