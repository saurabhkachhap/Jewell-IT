using System;
using TMPro;
using UnityEngine;

public class AlphaText : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;


    private TextMeshProUGUI _text;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseOpacity()
    {
        LeanTween.value(gameObject, OnValueChange, 0f, 1f, 0).setSpeed(speed).setEase(tweenType);
    }

    public void DecreaseOpacity()
    {
        LeanTween.value(gameObject, OnValueChange, 1f, 0f, 0).setSpeed(speed).setEase(tweenType).setOnComplete(StopAnimation);
    }

    private void StopAnimation()
    {
        LeanTween.cancelAll();
    }

    private void OnValueChange(float value)
    {
        _text.alpha = value;
    }
}
