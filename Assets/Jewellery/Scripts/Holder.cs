using UnityEngine;

public class Holder : MonoBehaviour
{
    private ScrollSnap _scrollSnap;

    private void Awake()
    {
        _scrollSnap = FindObjectOfType<ScrollSnap>();
    }

    public void DisplayNecklace()
    {
        transform.SetParent(_scrollSnap.selectedJewelleryBox);
       
        transform.localPosition = new Vector3(0f, 0.2f, 0.3f);
        transform.localRotation = Quaternion.Euler(-20f, 0f, 0f);
        transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }
}
