using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(JewelleryDesigner))]
public class DesignerInspector : Editor
{
    private JewelleryDesigner designer;
    private void OnSceneGUI()
    {
        
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        designer = target as JewelleryDesigner;

        if(GUILayout.Button("Add Anchors"))
        {
            designer.SpawnGems();
        }
    }
}
