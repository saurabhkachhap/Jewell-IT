using UnityEngine;

public class AlphaText : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;

    private RectTransform _textRect;
    
    private void Awake()
    {
        _textRect = GetComponent<RectTransform>();
    }

    public void IncreaseOpacity()
    {
        LeanTween.textAlpha(_textRect, 1f, 0.6f).setEase(tweenType);  
    }

    public void DecreaseOpacity()
    {
        LeanTween.textAlpha(_textRect, 0f, 0.6f).setEase(tweenType);
    }
}
