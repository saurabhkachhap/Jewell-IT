﻿using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private Vector3Variable _lastPickUpPoint;
    [SerializeField]
    private GameObject flickObj;
   
    private GameObject _gObj;
    private Plane _plane;
    private Vector3 _offset;
    private ObjectBehaviour _objectBehaviour;

    private string _selectableTag = "Selectable";

    //private ShockWave _shockWave;

    private Ray GenerateMouseRay()
    {
        var mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        var mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        var worldPosFar = Camera.main.ScreenToWorldPoint(mousePosFar);
        var worldPosNear = Camera.main.ScreenToWorldPoint(mousePosNear);
        var mr = new Ray(worldPosNear, worldPosFar - worldPosNear);
       
        return mr;
    }

    public void DeselectPiece()
    {
        flickObj.SetActive(false);
        if (!_gObj) return;
        if (_objectBehaviour)
        {
            _objectBehaviour.DisableBehaviour();
        }       
        _gObj = null;
        
    }

    public void MoveSelectedPiece()
    {
        if (!_gObj) return;
        var mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (_plane.Raycast(mRay, out var hit))
            _gObj.transform.position = mRay.GetPoint(hit) + _offset /*+ new Vector3(0f,0f,0.2f)*/;
        var pos = _gObj.transform.position;
        pos.y = 0.3f;
        _gObj.transform.position = pos;
    }

    public void SelectJewelleryPiece()
    {
        var mouseRay = GenerateMouseRay();

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out var hit))
        {
            if (hit.transform.CompareTag(_selectableTag))
            {
                Vibration.VibratePop();
                _gObj = hit.transform.gameObject;
                _objectBehaviour = _gObj.GetComponent<ObjectBehaviour>();
                _objectBehaviour.EnableBehaviour();

                var planePos = new Vector3(_gObj.transform.position.x, _gObj.transform.position.y + .3f, _gObj.transform.position.z);
                _plane = new Plane(Camera.main.transform.forward * -1f, planePos);

                var mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                _plane.Raycast(mRay, out var rayDistance);
                _offset = _gObj.transform.position  + new Vector3(0, 0f, 0.2f) - mRay.GetPoint(rayDistance);

            }
        }
    }

    public void StartFlick()
    {
        var mouseRay = GenerateMouseRay();

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out var hit))
        {
            //if (hit.transform.CompareTag(_selectableTag))
            {
                var obj = hit.transform;

                _plane = new Plane(Vector3.up, obj.transform.position);

                var mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                _plane.Raycast(mRay, out var rayDistance);
                _offset = obj.transform.position - mRay.GetPoint(rayDistance);
            }

            if (!flickObj.activeSelf)
            {
                flickObj.transform.position = hit.transform.position;
                flickObj.SetActive(true);              
            }
        }           
    }

    //long[] pattern = new long[] { 0, 5, 5, 5,0 };
    public void FlickObjects()
    {
        
        var mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (_plane.Raycast(mRay, out var hit))
        {
            flickObj.transform.position = mRay.GetPoint(hit);
        }
    }
}
