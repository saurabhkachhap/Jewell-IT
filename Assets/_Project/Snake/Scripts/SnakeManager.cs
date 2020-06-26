using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snake.Camere;

namespace Snake
{
    public class SnakeManager : MonoBehaviour
    {
        [SerializeField]
        private List<SnakeBody> bodyList = new List<SnakeBody>();

        public static SnakeManager instance;
        public float mimDistance = 0.9f;
        public float currentSpeed = 10f;
        public bool isReady;
        public GameObject blastEffect;

        private TopDownCamera _cam;
        private List<GameObject> sortedList = new List<GameObject>();

        private void Awake()
        {
            instance = this;
            _cam = FindObjectOfType<TopDownCamera>();
        }

        private void Start()
        {
            SetHead();
            //StartCoroutine(nameof(Delay));
            SetBodyToFollow();
            //Debug.Log(chosenHead);
            SetCamerTarget();
        }

        public void RegesterBody(SnakeBody body)
        {
            if (!bodyList.Contains(body))
            {
                bodyList.Add(body);
            }
        }

        public void SetHead()
        {
            var length = bodyList.Count - 1;
            //Debug.Log(length);
            bodyList[length].isHead = true;
           
        }

        public void SetCamerTarget()
        {
            _cam.SetTarget(bodyList[bodyList.Count - 1].transform);
        }

        public void SetBodyToFollow()
        {
            for (int i = bodyList.Count - 1; i >= 0; i--)
            {
                if (!bodyList[i].isHead)
                {
                    //Debug.Log(bodyList.Count);
                    bodyList[i].bodyToFollow = bodyList[i + 1];
                }
            }
        }

        public void PlayerIsReady()
        {
            isReady = true;
        }

        public void SortColors()
        {
            //Debug.Log("c");
            for (int i = bodyList.Count - 1; i >= 0; i--)
            {
                var currentColor = bodyList[i].bodyColor;
                var nextColor = bodyList[i - 1].bodyColor;

                if(currentColor == nextColor)
                {
                    sortedList.Add(bodyList[i].gameObject);
                }
                else
                {
                    sortedList.Add(bodyList[i].gameObject);
                    if (sortedList.Count > 2)
                    {
                        StartCoroutine(nameof(DestroyObjects));
                    }
                    else
                    {
                        sortedList.Clear();
                    }                       
                    return;
                }
            }           
        }

        private IEnumerator DestroyObjects()
        {
            
            {   
                for (int i = 0; i < sortedList.Count; i++)
                {
                    var count = bodyList.Count - 1;
                    Instantiate(blastEffect, bodyList[count].transform.position, blastEffect.transform.rotation);
                    Destroy(bodyList[count].gameObject);
                    bodyList.RemoveAt(count);
                    //Debug.Log(count);
                    SetHead();
                    SetBodyToFollow();
                    yield return new WaitForSeconds(0.15f);
                   
                }
                sortedList.Clear();
                SetCamerTarget();
            }
           
        }
    }
}

