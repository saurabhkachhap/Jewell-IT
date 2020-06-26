using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private Color changeColorTo;
    private Color _initialColor;
    [SerializeField]
    private Material mymat;

    private void Awake()
    {
        //mymat = GetComponent<MeshRenderer>().material;
        _initialColor = mymat.color;
    }

    private void Update()
    {
        //HeighlightColor();
    }
    public void HeighlightColor()
    {
        //while (true)
        {
            var col = Color.Lerp(_initialColor, changeColorTo, Time.deltaTime * 3f);
            mymat.color = col;
            Debug.Log("change color");
        }
        
    }
}
