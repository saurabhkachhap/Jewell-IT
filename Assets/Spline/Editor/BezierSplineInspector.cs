using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(BezierSpline))]
public class BezierSplineInspector : Editor
{
    private BezierSpline _spline;
    private Transform _handleTransform;
    private Quaternion _handleRotationa;
    private int _selectedIndex = -1; 

    private const float LINESCALE = 0.5f;
    private const int STEPS_PER_CURVE = 10;
    private const float HANDLESIZE = 0.04f;
    private const float PICKSIZE = 0.06f;

    private static Color[] modeColors = { Color.white, Color.yellow, Color.cyan };
    
    public bool showDirection;

    private void OnSceneGUI()
    {
        _spline = target as BezierSpline;
        _handleTransform = _spline.transform;
        _handleRotationa = Tools.pivotRotation == PivotRotation.Local ? _handleTransform.rotation : Quaternion.identity;

        var p0 = ShowPoint(0);
        for (int i = 1; i < _spline.ControllPointCount; i+=3)
        {
            var p1 = ShowPoint(i);
            var p2 = ShowPoint(i + 1);
            var p3 = ShowPoint(i + 2);

            Handles.color = Color.gray;
            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p2, p3);

            Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
            p0 = p3;
        }

        if (showDirection)
        {
            GetDirection();
        }
        //SetPosition();
    }

    private Vector3 ShowPoint(int index)
    {
        var point = _handleTransform.TransformPoint(_spline.GetControllPoint(index));
        var size = HandleUtility.GetHandleSize(point);
        Handles.color = modeColors[(int)_spline.GetControllPointMode(index)];
        if(Handles.Button(point, _handleRotationa, HANDLESIZE * size, PICKSIZE * size, Handles.DotHandleCap))
        {
            _selectedIndex = index;
            Repaint();
        }

        if (_selectedIndex == index)
        {
            EditorGUI.BeginChangeCheck();
            point = Handles.DoPositionHandle(point, _handleRotationa);
          
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_spline, "Move Position");
                EditorUtility.SetDirty(_spline);
                _spline.SetControllPoint(index,_handleTransform.InverseTransformPoint(point));
            }
        }
        return point;
    }

    private void GetDirection()
    {
        var point = _spline.GetPoint(0f);
        Handles.color = Color.green;
        Handles.DrawLine(point, point + _spline.GetDirection(0f) * LINESCALE);

        var steps = STEPS_PER_CURVE * _spline.CurveCount;
        for (int i = 1; i <= steps; i++)
        {
            point = _spline.GetPoint(i / (float)steps);
            Handles.color = Color.green;
            Handles.DrawLine(point, point + _spline.GetDirection(i / (float)steps) * LINESCALE);
        }
    }

    private void SetPosition()
    {
        var point = _spline.GetPoint(0f);
        var child = _spline.transform.GetChild(0);
        child.position = point;

        var steps = STEPS_PER_CURVE * _spline.CurveCount;
        for (int i = 1; i < steps; i++)
        {
            point = _spline.GetPoint(i / (float)steps);
            child = _spline.transform.GetChild(i);
            child.position = point;
        }

    }

    public override void OnInspectorGUI()
    {
        if(_selectedIndex >= 0 && _selectedIndex < _spline.ControllPointCount)
        {
            DrawSelectedPointInspector();
        }
        if(GUILayout.Button("Add Curve"))
        {
            Undo.RecordObject(_spline, "Add Curve");
            _spline.AddCurve();
            EditorUtility.SetDirty(_spline);
        }

        EditorGUI.BeginChangeCheck();
        var flag = EditorGUILayout.Toggle("Showdirection",showDirection);
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_spline);
            showDirection = flag;
        }
    }

    private void DrawSelectedPointInspector()
    {
        GUILayout.Label("Selected Point");
        EditorGUI.BeginChangeCheck();
        var point = EditorGUILayout.Vector3Field("Position", _spline.GetControllPoint(_selectedIndex));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_spline, "Move Point");
            EditorUtility.SetDirty(_spline);
            _spline.SetControllPoint(_selectedIndex, point);
        }

        EditorGUI.BeginChangeCheck();
        var mode = (BezierControlPointMode)EditorGUILayout.EnumPopup("Mode", _spline.GetControllPointMode(_selectedIndex));
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(_spline, "Change Point Mode");
            _spline.SetControllPointMode(_selectedIndex, mode);
            EditorUtility.SetDirty(_spline); 
        }
    }
}
