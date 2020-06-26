using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private float scaleAmount = 1.2f;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private LeanTweenType tweenType;
    private Vector3 _originalScale;

    private ChangeColor _changeColor;

    private void Awake()
    {
        _originalScale = transform.localScale;
        _changeColor = GetComponent<ChangeColor>();
    }

    public void ScleBody()
    {
        LeanTween.scale(gameObject, transform.localScale * scaleAmount, 0f).setSpeed(speed).setEase(tweenType);
        
    }

    public void StopAnimation()
    {
        LeanTween.scale(gameObject, _originalScale, 0f).setSpeed(speed).setEase(tweenType);
    
        LeanTween.cancel(gameObject);
    }
}
