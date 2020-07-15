using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

[CustomEditor(typeof(JewelleryDesigner))]
public class DesignerInspector : Editor
{
    private JewelleryDesigner designer;
    private void OnSceneGUI()
    {
        designer = target as JewelleryDesigner;
        designer.SpawnGems();


    }

    //public override void OnInspectorGUI()
    //{
    //    DrawDefaultInspector();
       

    //    if(GUILayout.Button("Add Anchors"))
    //    {
    //        designer.SpawnGems();
    //    }
    //}
}
