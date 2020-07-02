using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 rotation;
    [SerializeField]
    private LeanTweenType tweenType;

    void Start()
    {
        RotateAnimation();
    }

    private void RotateAnimation()
    {
        LeanTween.rotate(gameObject, rotation, 0f).setSpeed(speed).setEase(tweenType).setLoopPingPong(1).setOvershoot(5f);
    }

   
}
