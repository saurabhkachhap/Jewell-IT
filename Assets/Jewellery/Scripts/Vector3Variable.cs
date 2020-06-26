using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Variable : ScriptableObject
{
    private Vector3 position;

    public void SetValue(Vector3 value)
    {
        position = value;
    }

    public Vector3 GetValue()
    {
        return position;
    }
}

