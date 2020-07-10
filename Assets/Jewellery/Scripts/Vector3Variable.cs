using UnityEngine;

[CreateAssetMenu]
public class Vector3Variable : ScriptableObject
{
    [SerializeField]
    private Vector3 position;

    public void SetValue(Vector3 value)
    {
        position = value;
    }

    public Vector3 GetValue()
    {
        return position;
    }

    //private void OnEnable()
    //{
    //    position = Vector3.zero;
    //}
}

