using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    private RectTransform _rect;
    private Vector3 _originalScale;
    [SerializeField]
    private Vector3 scaleTo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;
    [SerializeField]
    private LeanTweenType loopType;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _originalScale = _rect.localScale;
    }
    private void OnEnable()
    {
        PopAnimation();    
    }

    private void PopAnimation()
    {
        LeanTween.scale(_rect, scaleTo, 0f).setSpeed(speed).setEase(tweenType).setLoopType(loopType);
    }

    private void OnDisable()
    {
        _rect.localScale = _originalScale;
    }
}
