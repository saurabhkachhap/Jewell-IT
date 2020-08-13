using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Feedbacks : MonoBehaviour
{
    [SerializeField]
    private string[] feedbackStrings;
    [SerializeField]
    private Text feedbackText;
    [SerializeField]
    private TransformProperty anchorProperty;

    //private ScaleUI _scaleUI;
    private AlphaText _alphaText;
    private Camera _cam;
    private MoveUI _moveUI;
    private Vector3 _anchorScreenPos;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private void Awake()
    {
        _alphaText = feedbackText.GetComponent<AlphaText>();
        _moveUI = feedbackText.GetComponent<MoveUI>();
        _cam = Camera.main;
    }
    public void GiveFeedback()
    {   
        int index = Random.Range(0, feedbackStrings.Length);
        feedbackText.text = feedbackStrings[index];
        var anchorWorldPos = SvedObject.GetHitObject().transform.position;
        _anchorScreenPos = _cam.WorldToScreenPoint(anchorWorldPos);
        _anchorScreenPos = new Vector3(_anchorScreenPos.x, _anchorScreenPos.y + 70f, _anchorScreenPos.z);
        feedbackText.rectTransform.position = _anchorScreenPos;

        _alphaText.IncreaseOpacity();
        StartCoroutine(nameof(DisableFeedback));
    }

    private IEnumerator DisableFeedback()
    {
        yield return _waitForSeconds;
        _alphaText.DecreaseOpacity();
        var viewPort = _cam.ScreenToViewportPoint(_anchorScreenPos);
        _moveUI.MoveUiPosition(viewPort);
    }
}
