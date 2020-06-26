using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeBody : MonoBehaviour
    {
        //private SnakeBody head;
        public bool isHead;
        public SnakeBody bodyToFollow;
        public Color bodyColor;
        //public bool isRayCasting;

        //private float timeToMove;
        //private float intervel = 0.3f;
        private int collectableLayer;
        //private SnakeManager _snakeManager;

        private void Awake()
        {
            collectableLayer = LayerMask.GetMask("Collectable");
            //_snakeManager = FindObjectOfType<SnakeManager>();
            
            //layerMask = ~layerMask;      
            //Debug.Log(layerMask);
        }

        private void OnEnable()
        {
            bodyColor = GetComponent<MeshRenderer>().material.color;
            
        }

        private void Start()
        {
            SnakeManager.instance.RegesterBody(this);
            //SnakeManager.instance.SetBodyToFollow(this);
        }

        void Update()
        {
            if (!SnakeManager.instance.isReady) return;
            MoveBody();
        }

        private void MoveBody()
        {
            if (isHead)
            {
                transform.position += transform.forward * Time.smoothDeltaTime * SnakeManager.instance.currentSpeed;

                if (Input.GetAxis("Horizontal") != 0)
                {
                    transform.Rotate(Vector3.up * 300f * Time.deltaTime * Input.GetAxis("Horizontal"));
                }

                //Debug.Log("head" + gameObject.name);
                //Debug.DrawRay(transform.position, transform.forward, Color.red, 0.5f);
                if (Physics.Raycast(transform.position, transform.forward, out var hit, 0.5f, collectableLayer))
                {
                    #region Collision Logic
                    var hitObj = hit.transform.GetComponent<SnakeBody>();
                    if (hitObj)
                    {
                        isHead = false;
                        hitObj.enabled = true;
                        hitObj.gameObject.layer = 8;
                        hitObj.transform.rotation = transform.rotation;
                        StartCoroutine(nameof(SetHeadValue));
                        //SnakeManager.instance.SortColors();
                        //Debug.Log("hitting some object");
                    }
                    #endregion Collision Logic
                    //SnakeManager.instance.SetHead();
                    //SnakeManager.instance.SetBodyToFollow();
                    //SnakeManager.instance.SetCamerTarget();
                }
            }              
            else
            {
                var dist = Vector3.Distance(bodyToFollow.transform.position, transform.position);
                var newPos = new Vector3(bodyToFollow.transform.position.x, transform.position.y, bodyToFollow.transform.position.z);
                //Debug.Log(newPos);

                //newPos.y = bodyToFollow.transform.position.y;

                var t = Time.deltaTime * dist / SnakeManager.instance.mimDistance * SnakeManager.instance.currentSpeed;

                if (t > 0.5f)
                    t = 0.5f;

                transform.position = Vector3.Lerp(transform.position, newPos, t);
                transform.rotation = Quaternion.Slerp(transform.rotation, bodyToFollow.transform.rotation, t);

            }
        }

        private IEnumerator SetHeadValue()
        {
            yield return new WaitForEndOfFrame();
            SnakeManager.instance.SetHead();
            SnakeManager.instance.SetBodyToFollow();
            SnakeManager.instance.SetCamerTarget();
            SnakeManager.instance.SortColors();
        }
    }
}
