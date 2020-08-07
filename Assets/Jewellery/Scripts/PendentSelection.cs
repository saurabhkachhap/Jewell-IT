using UnityEngine;

public class PendentSelection : MonoBehaviour
{
    private Transform pendentAnchorPoint;
    private GameObject _currentSelection;
    private GameObject _lastSelection;
    private Holder _holder;

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
}
