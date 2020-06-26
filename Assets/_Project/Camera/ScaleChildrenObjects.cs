using UnityEngine;

namespace SnakeColor.NewScripts
{
    public class ScaleChildrenObjects : MonoBehaviour
    {
        [SerializeField] private Vector3 scaleAmount;
        [SerializeField] private float speed;
        [SerializeField] private LeanTweenType ease;
        [SerializeField] private float delay;
        [SerializeField] private float distanceToPlayer;

        private GameObject[] _childObjects;
        private Transform _player;

        private void Awake()
        {
           _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Start()
        {
            var childCount = transform.childCount;
            _childObjects = new GameObject[childCount];
            for (int i = 0; i < childCount; i++)
            {
                _childObjects[i] = transform.GetChild(i).gameObject;
            }
        }

        private void OnEnable()
        {
            InvokeRepeating(nameof(CheckDistanceFromPlayer), 0, 0.2f);
        }

        private void CheckDistanceFromPlayer()
        {
            if (Vector3.Distance(transform.position, _player.position) < distanceToPlayer)
            {
                //Debug.Log("player is near");
                CancelInvoke();
                ScaleObjects();
            }
        }

        private void ScaleObjects()
        {
            for (int i = 0; i < _childObjects.Length; i++)
            {
                LeanTween.scale(_childObjects[i], _childObjects[i].transform.localScale + scaleAmount, 1f).setSpeed(speed).setEase(ease).setDelay(i * delay);
            }
            
        }
    }
}
