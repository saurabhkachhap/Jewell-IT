using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskDiscription : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI discriptionText;
    [SerializeField]
    private string[] taskDiscription;
    [Space]
    [SerializeField]
    private TextMeshProUGUI tutorialText;
    [SerializeField]
    private string[] tutorialDiscription;
    [SerializeField]
    private Image[] taskIndicator;

    int i = 0;

    private void Awake()
    {
        SetTaskDiscription();
    }

    public void SetTaskDiscription()
    {
        if (i > taskDiscription.Length - 1) return;
        discriptionText.text = taskDiscription[i];
        SetTutorialText();
        SetTaskIndicator();
        i++;
    }

    private void SetTutorialText()
    {
        if (i > tutorialDiscription.Length - 1)
        {
            tutorialText.enabled = false;
        }
        else
        {
            tutorialText.text = tutorialDiscription[i];
        }       
    }

    private void SetTaskIndicator()
    {
        if (i > taskIndicator.Length - 1) return;
        //Debug.Log("enable image");
        taskIndicator[i].enabled = true;
    }
    
}
