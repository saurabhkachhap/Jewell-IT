using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Camere
{
    public class TopDownCamera : MonoBehaviour
    {
        [SerializeField]
        private float height = 10f;
        [SerializeField]
        private float distance = 20f;
        [SerializeField]
        private float angle = 45f;
        [SerializeField]
        private float smoothTime = 0.25f;

        private Transform target;
        private Vector3 currentVelocity;
        private Vector3 reltPos;

        private void Start()
        {
            HandleCamera();
        }

        private void LateUpdate()
        {
            HandleCamera();
        }

        private void HandleCamera()
        {
            if (!target) return;
           
            var worldPosition = Vector3.forward * distance + Vector3.up * height;
            //Debug.DrawLine(target.position, worldPosition, Color.red);

            var rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;
            //Debug.DrawLine(target.position, rotatedVector, Color.green);

            var flatTargetPosition = target.position;
            flatTargetPosition.y = 0f;

            var finalPosition = flatTargetPosition + rotatedVector;
            //Debug.DrawLine(target.position, finalPosition, Color.blue);
            //var finalCamPos = Vector3.SmoothDamp(transform.position, finalPosition, ref currentVelocity, smoothTime);
            transform.position = finalPosition;
            transform.LookAt(flatTargetPosition);
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}

