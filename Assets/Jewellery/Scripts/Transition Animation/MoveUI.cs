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
    [SerializeField]
    private LeanTweenType loopType;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        MoveUiPosition();    
    }

    private void MoveUiPosition()
    {
        LeanTween.move(_rect, moveTo, 0f).setSpeed(speed).setEase(tweenType).setLoopType(loopType);
    }

    public void MoveUiPosition(Vector3 pos)
    {
        var newPos = moveTo + pos;
        LeanTween.moveY(_rect, newPos.y, 1f).setEase(tweenType);
    }
}
