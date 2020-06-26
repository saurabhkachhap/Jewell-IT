using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor
{
    private BezierCurve _bezierCurve;
    private Transform _handleTransform;
    private Quaternion _handleRotation;

    private const int _lineSteps = 10;
    private const float _directionScale = 0.5f;

    private void OnSceneGUI()
    {
        _bezierCurve = target as BezierCurve;
        _handleTransform = _bezierCurve.transform;
        _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleTransform.rotation : Quaternion.identity;

        var p0 = ShowPoints(0);
        var p1 = ShowPoints(1);
        var p2 = ShowPoints(2);
        var p3 = ShowPoints(3);

        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);

        ShowDirections();
        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);

        var lineStart = _bezierCurve.GetPoint(0);
        Handles.color = Color.green;
        Handles.DrawLine(lineStart, lineStart + _bezierCurve.GetDirection(0f));
        for (int i = 1; i <= _lineSteps; i++)
        {
            var lineEnd = _bezierCurve.GetPoint(i / (float)_lineSteps);
            Handles.color = Color.white;
            Handles.DrawLine(lineStart, lineEnd);
            Handles.color = Color.green;
            Handles.DrawLine(lineEnd, lineEnd + _bezierCurve.GetDirection(i / (float)_lineSteps));
            lineStart = lineEnd;
        }

    }

    private void ShowDirections()
    {
        Handles.color = Color.green;
        Vector3 point = _bezierCurve.GetPoint(0f);
        Handles.DrawLine(point, point + _bezierCurve.GetDirection(0f) * _directionScale);
        for (int i = 1; i <= _lineSteps; i++)
        {
            point = _bezierCurve.GetPoint(i / (float)_lineSteps);
            Handles.DrawLine(point, point + _bezierCurve.GetDirection(i / (float)_lineSteps) * _directionScale);
        }
    }
    
    public Vector3 ShowPoints(int index)
    {
        var point = _handleTransform.TransformPoint(_bezierCurve.points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.PositionHandle(point, _handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            _bezierCurve.points[index] = _handleTransform.InverseTransformPoint(point);
        }

        return point;
    }
}
