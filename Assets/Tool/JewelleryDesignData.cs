using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Jewellery Design MainData Container")]
public class JewelleryDesignData : ScriptableObject
{
    public enum Size
    {
        Small, Medium, Large
    }
    public Size size = Size.Small;

    public GameObject[] jewellerySize;

    public Theme theme;

    public TempelateData[] tempelateDesignData;

}
