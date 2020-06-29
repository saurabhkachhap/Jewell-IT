using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Vector3Variable posContainer;
    [SerializeField]
    private TransformProperty anchorProperty;

    private float _distance;
    private Rigidbody _rb;
    private string _untag = "Untagged";
    private ScoreManager _scoreManager;
    private Holder _holder;
    //private (Vector3, Quaternion, bool) _anchorProperty;

    private UndoBooster _undoBooster;

    private void Awake()
    {
        _undoBooster = FindObjectOfType<UndoBooster>();
        _rb = GetComponent<Rigidbody>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _holder = FindObjectOfType<Holder>();
    }

    private void Update()
    {
        if (anchorProperty.GetTransformProperty().Item3)
        {
            _distance = Vector3.Distance(transform.position, anchorProperty.GetTransformProperty().Item1);
            if (_distance >= 0.01f)
            {
                var newPos = Vector3.Lerp(transform.position, anchorProperty.GetTransformProperty().Item1, 35f * Time.deltaTime);
                transform.position = newPos;
                transform.rotation = anchorProperty.GetTransformProperty().Item2;
                //Debug.Log("corutin");
            }
            else
            {
                anchorProperty.SetTransformProperty(false);
                anchorProperty.GetHitObject().SetActive(false);

                _scoreManager.CalculateScore(anchorProperty.GetAnchorType(), anchorProperty.GetCurrentSelectedPiece());

                gameObject.tag = _untag;
                gameObject.transform.parent = _holder.transform;
                _undoBooster.AddToHistory(gameObject, posContainer.GetValue(), anchorProperty.GetHitObject());
                this.enabled = false;
                Vibration.VibratePeek();
            }
        }
        else
        {
            _distance = Vector3.Distance(transform.position, posContainer.GetValue());
            if (_distance > 0.1f)
            {
                var newPos = Vector3.Lerp(transform.position, posContainer.GetValue(), 6f * Time.deltaTime);
                transform.position = newPos;
                //Debug.Log("corutin");
            }
            else
            {
                _rb.isKinematic = false;
                this.enabled = false;
            }
        }
       
    }
}
