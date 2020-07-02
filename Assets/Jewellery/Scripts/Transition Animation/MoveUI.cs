using UnityEngine;

public class MoveUI : MonoBehaviour
{
    private RectTransform _rect;
    [SerializeField]
    private Vector3 moveTo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        MoveUiPosition();    
    }

    private void MoveUiPosition()
    {
        LeanTween.move(_rect, moveTo, 0f).setSpeed(speed).setEase(tweenType);
    }
}
