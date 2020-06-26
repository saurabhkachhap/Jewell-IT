using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor
{
    private void OnSceneGUI()
    {
        var line = target as Line;
        var handleTransform = line.transform;
        var handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

        var p0 = handleTransform.TransformPoint(line.p0);
        var p1 = handleTransform.TransformPoint(line.p1);

        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        
        EditorGUI.BeginChangeCheck();
        p0 = Handles.PositionHandle(p0, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            line.p0 = handleTransform.InverseTransformPoint(p0);
        }

        EditorGUI.BeginChangeCheck();
        p1 = Handles.PositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            line.p1 = handleTransform.InverseTransformPoint(p1);
        }
    }
}
