using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private float _timeToMove;
    //private float _intervel = 0.1f;
    private SelectionManager _selectionManager;
    private bool _once;
    public TextMeshProUGUI debugTex;

    public GameObject particle;


    private void Awake()
    {
        _selectionManager = GetComponent<SelectionManager>();    
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _timeToMove = Time.deltaTime;

                //Debug.Log(_timeToMove);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log(_timeToMove);
                if (_timeToMove < 0.08f)
                {
                    if (!_once)
                    {
                        _once = true;
                        _selectionManager.StartFlick();
                        //Debug.Log("swipe");
                    }
                    _selectionManager.FlickObjects();
                }
                else /*if (_timeToMove >= 0f)*/
                {
                    //if (!_once)
                    //{                    
                    //    _once = true;
                    //    //_selectionManager.SelectJewelleryPiece();
                    //    Debug.Log("drag drop");
                    //}
                    _selectionManager.MoveSelectedPiece();

                }
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                _timeToMove += Time.deltaTime;
                if(_timeToMove > 0.08f)
                {
                    if (!_once)
                    {
                        _once = true;
                        _selectionManager.SelectJewelleryPiece();                       
                        //Debug.Log("drag drop");
                    }
                }
                _selectionManager.MoveSelectedPiece();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _selectionManager.DeselectPiece();
                _once = false;
                Vibration.Cancel();
                //particle.SetActive(false);
            }

        }     

        
    }
}
