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
        transform.SetParent(_scrollSnap.selectedJewelleryBox.GetChild(0));
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 8;
        }

        transform.localPosition = new Vector3(0f, 0.35f, -0.65f);
        transform.localRotation = Quaternion.Euler(65.5f, 0f, 0f);
        transform.localScale = Vector3.one;
    }
}
