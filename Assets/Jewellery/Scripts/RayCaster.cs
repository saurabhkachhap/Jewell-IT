using UnityEngine;

public class RayCaster : MonoBehaviour
{
    //[SerializeField]
    public JewellerPiece jewellerPiece;
    [SerializeField]
    private Vector3Variable _lastPickUpLocation;
    [SerializeField]
    private TransformProperty anchorTransform;

    private LayerMask _selectableLayer;
    private GameObject _lastHitObj;
    private GameObject _currentHitObject;
    private Scale _scale;
    

    private void Awake()
    {
        _selectableLayer = 1 << 14;
    }

    private void OnEnable()
    {
        _lastPickUpLocation.SetValue(transform.position);
        anchorTransform.SetCurrentSelectedPiece(jewellerPiece.pieceType);
    }

    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out var hit, 0.5f,_selectableLayer))
        {
            _currentHitObject = hit.transform.gameObject;
            if (_currentHitObject != _lastHitObj)
            {
                if (_lastHitObj)
                {
                    _lastHitObj.GetComponent<Scale>().StopAnimation();
                }

                //Debug.Log("checking correct layer");
                _scale = _currentHitObject.GetComponent<Scale>();
                var anchor = _currentHitObject.GetComponent<Anchor>();
                _scale.ScleBody();
                _lastHitObj = _currentHitObject;
                anchorTransform.SetTransformProperty(_currentHitObject.transform.position, _currentHitObject.transform.rotation,true);
                anchorTransform.SetTransformProperty(_currentHitObject);
                anchorTransform.SetAnchorType(anchor.anchorType.pieceType);
            }
        }
        else
        {
            //Debug.Log("incorrect layer");
            if (_scale)
            {
                _scale.StopAnimation();
                _lastHitObj = null;
                anchorTransform.SetTransformProperty(false);
            }
           
        }
        Debug.DrawRay(transform.position, Vector3.down * .5f, Color.red);
    }

    private void OnDisable()
    {
        if (!_scale) return;
        _scale.StopAnimation();
        _scale = null;
    }
}
