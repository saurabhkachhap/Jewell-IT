using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake.Camere
{
    public class CamerFollow : MonoBehaviour
    {
        [SerializeField]
        private Vector3 defaultDistacne;
        [SerializeField]
        private float distacneDamp;
        [SerializeField]
        private float rotationalDamp;

        private Transform _target;
        private Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }

        private void LateUpdate()
        {
            var toPos = _target.position + (_target.rotation * defaultDistacne);
            var curPos = Vector3.Lerp(myTransform.position, toPos, distacneDamp * Time.deltaTime);
            myTransform.position = curPos;

            var toRot = Quaternion.LookRotation(_target.position - myTransform.position, _target.up);
            var curRot = Quaternion.Slerp(myTransform.rotation, toRot, rotationalDamp * Time.deltaTime);
            myTransform.rotation = curRot;
        }

        public void SetTarget(Transform newTarget)
        {
            //_changedTarget._target = newTarget;
            _target = newTarget;
            
        }
    }

   
}

