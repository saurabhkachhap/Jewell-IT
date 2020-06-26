using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private float floatValue;

    public void Reset()
    {
        floatValue = 0f;
    }

    public void SetValue(float val)
    {
        floatValue = val;
    }

    public float GetValue()
    {
        return floatValue;
    }
}
