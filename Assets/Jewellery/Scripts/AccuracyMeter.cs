using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyMeter : MonoBehaviour
{
    [SerializeField]
    private FloatVariable score;
    [SerializeField]
    private Image meter;
    [SerializeField]
    private TextMeshProUGUI accuracyText;


    private void Update()
    {
        var accuracy = score.GetValue();
        meter.fillAmount = accuracy / 100f;
        if(accuracyText)
        accuracyText.text = accuracy.ToString("00") + "%";
        //Debug.Log(meter.fillAmount);
    }
}
