using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Delay : MonoBehaviour
{
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        StartCoroutine(nameof(SetDelay));
    }

    private IEnumerator SetDelay()
    {
        yield return new WaitForSeconds(5f);
        buttonText.enabled = true;
    }
}
