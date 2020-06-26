using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraTarget : MonoBehaviour
{
    public Transform _target;
    private float speed = 1f;
    private Quaternion newRot;
    private Vector3 relPos;


    // Update is called once per frame
    void Update()
    {
        if(_target != null)
        {
            relPos = _target.position - transform.position;
            newRot = Quaternion.LookRotation(relPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.time * 0.5f);
        }
    }
}
