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

    public void GiveFeedback()
    {   
        int index = Random.Range(0, feedbackStrings.Length);
        feedbackText.text = feedbackStrings[index];
        feedbackText.enabled = true;
        StartCoroutine(nameof(DisableFeedback));
    }

    private IEnumerator DisableFeedback()
    {
        yield return new WaitForSeconds(1.5f);
        feedbackText.enabled = false;
    }
}
