using UnityEngine;
using UnityEngine.UI;

public class PendentSelection : MonoBehaviour
{
    private Transform pendentAnchorPoint;
    private GameObject _currentSelection;
    private GameObject _lastSelection;
    private Holder _holder;
    public bool _isSelected;
    private Button _lastSelected;
    [SerializeField]
    private Sprite selectedImg;
    [SerializeField]
    private Sprite deselectedImg;

    private void Awake()
    {
        _holder = FindObjectOfType<Holder>();     
    }


    public void SelectPendent(GameObject pendent)
    {
        if (!pendentAnchorPoint)
        {
            pendentAnchorPoint = FindObjectOfType<PendantAnchor>().transform;
        }
        
        if (_lastSelection)
        {
            Destroy(_lastSelection);
        }
        //pendentAnchorPoint.position = pendentAnchorPoint.TransformPoint(pendentAnchorPoint.position);
        _currentSelection = Instantiate(pendent, pendentAnchorPoint.position, pendentAnchorPoint.rotation);
        _currentSelection.transform.SetParent(_holder.transform);
        _lastSelection = _currentSelection;
    }

    public void SetImage(Button currentSelcted)
    {
        Debug.Log(currentSelcted);
        var img = currentSelcted.GetComponent<Image>();
        if (currentSelcted != _lastSelected)
        {
            _lastSelected = currentSelcted;
        }
       
        _isSelected = !_isSelected;

        if (_isSelected)
        {
            Debug.Log("button selected");
            img.sprite = selectedImg;
        }
        else
        {
            Debug.Log("not selected");
            img.sprite = deselectedImg;
        }
       
    }
}
