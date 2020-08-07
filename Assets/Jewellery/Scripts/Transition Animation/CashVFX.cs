using UnityEngine;

public class CashVFX : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] moveObjects;
    [SerializeField]
    private Vector3 moveTo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;

    [ContextMenu("Move")]
    public void TriggerEffect()
    {
        for (int i = 0; i < moveObjects.Length; i++)
        {
            LeanTween.move(moveObjects[i], moveTo, 0f).setSpeed(speed).setEase(tweenType).setDelay(i * 0.2f);
        }
    }


}
