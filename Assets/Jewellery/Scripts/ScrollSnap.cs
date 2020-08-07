﻿using UnityEngine;

public class ScrollSnap : MonoBehaviour
{
    [SerializeField]
    private RectTransform panel;
    [SerializeField]
    private RectTransform[] bttn;
    [SerializeField]
    private RectTransform center;
    [SerializeField]
    private RectTransform jbAnchor;
    [SerializeField]
    private GameObject[] pageDot;
    [SerializeField]
    private GameObject starParticle;

    private float[] _distance;
    private bool _dragging = false;
    private int _bttnDistance;
    private int _minButtonNum;

    public RectTransform selectedJewelleryBox { private set; get; }

    private void Start()
    {
        _distance = new float[bttn.Length];
        _bttnDistance = (int)Mathf.Abs(bttn[1].anchoredPosition.x - bttn[0].anchoredPosition.x);
    }

    private void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            _distance[i] = Mathf.Abs(center.position.x - bttn[i].position.x);
        }
        
        var minDistance = Mathf.Min(_distance);       
        for (int i = 0; i < bttn.Length; i++)
        {
            if(minDistance == _distance[i])
            {
                pageDot[_minButtonNum].SetActive(false);
                _minButtonNum = i;
                selectedJewelleryBox = bttn[i];
                pageDot[i].SetActive(true);
            }
        }

        if (!_dragging)
        {
            LerpToButton(_minButtonNum * -_bttnDistance);
        }
    }

    private void LerpToButton(int position)
    {
        var newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 7f);
        var newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        _dragging = true;
    }

    public void EndDrag()
    {
        _dragging = false;
    }

    public void DisplaySelectedJewelleryBox()
    {
        selectedJewelleryBox.transform.SetParent(jbAnchor);
        selectedJewelleryBox.anchoredPosition = Vector2.zero;
        selectedJewelleryBox.transform.localPosition = Vector3.zero;
        selectedJewelleryBox.localRotation = Quaternion.identity;
        selectedJewelleryBox.transform.localScale = Vector3.zero;
        starParticle.SetActive(true);
        LeanTween.scale(selectedJewelleryBox, Vector3.one, 0).setSpeed(1.5f).setEase(LeanTweenType.easeOutElastic);
        //ResetTransform();
    }
}
