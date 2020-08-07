using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private Vector3 posToMove;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;
    [SerializeField]
    private LeanTweenType loopType;

    private void Start()
    {
        MoveTransition();
    }

    public void MoveTransition()
    {
        LeanTween.move(gameObject, posToMove, 0f).setSpeed(speed).setEase(tweenType).setLoopType(loopType);
    }
}
