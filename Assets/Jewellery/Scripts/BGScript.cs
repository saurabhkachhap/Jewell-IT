using UnityEngine;

public class BGScript : MonoBehaviour
{
    [SerializeField]
    private Color[] Bgcolors;
    [SerializeField]
    private Renderer _mat;

    private void Awake()
    {
        _mat = GetComponent<Renderer>();
        ChangeBgColor(0);
    }

    public void ChangeBgColor(int i)
    {
        //Debug.Log("color changed");
        _mat.sharedMaterial.SetColor("_BaseColor", Bgcolors[i]);
    }
}
