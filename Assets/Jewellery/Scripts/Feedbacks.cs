using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Feedbacks : MonoBehaviour
{
    [SerializeField]
    private string[] feedbackStrings;
    [SerializeField]
    private TextMeshProUGUI feedbackText;
    [SerializeField]
    private TransformProperty anchorProperty;

    private ScaleUI _scaleUI;

    private void Awake()
    {
        _scaleUI = feedbackText.GetComponent<ScaleUI>();
    }
    public void GiveFeedback()
    {   
        int index = Random.Range(0, feedbackStrings.Length);
        feedbackText.text = feedbackStrings[index];
        var anchorWorldPos = anchorProperty.GetHitObject().transform.position;
        var anchorScreenPos = Camera.main.WorldToScreenPoint(anchorWorldPos);
        feedbackText.rectTransform.position = anchorScreenPos;
        //feedbackText.enabled = true;
        _scaleUI.enabled = false;
        StartCoroutine(nameof(DisableFeedback));
    }

    private IEnumerator DisableFeedback()
    {
        yield return new WaitForSeconds(1f);
        _scaleUI.enabled = true;
    }
}
