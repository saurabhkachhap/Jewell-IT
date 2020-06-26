using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject dustFx;

    private Rigidbody _rigidbody;
    private RayCaster _rayCaster;
    private Mover _mover;
    private Vector3 _originalScale;
    private GameObject _particle;

    private void Awake()
    {
        _originalScale = transform.localScale;
        _rigidbody = GetComponent<Rigidbody>();
        _rayCaster = GetComponent<RayCaster>();
        _mover = GetComponent<Mover>();
    }
    public void EnableBehaviour()
    {
        transform.localScale *= 1.2f;
        _rigidbody.isKinematic = true;
        _rayCaster.enabled = true;
        dustFx.SetActive(true);
        _particle = Instantiate(dustFx, transform);
    }

    public void DisableBehaviour()
    {
        transform.localScale = _originalScale;
        _rayCaster.enabled = false;
        _mover.enabled = true;
        Destroy(_particle);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.layer == 14)
    //    {
    //        Debug.Log("collision detected");
    //        other.gameObject.SetActive(false);
    //        this.enabled = false;
    //    }
    //}
}
