using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private FloatVariable scoreValue;
    [SerializeField]
    private int noOfJewelleryPieces;
    [SerializeField]
    private FloatVariable totalScore;
    [SerializeField]
    private TransformProperty anchorProperty;
    //[SerializeField]
    //private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject pendentDesignWindow;
    [SerializeField]
    private GameObject jewelleryBox;
    [SerializeField]
    private GameObject autoFillWindow;
    [SerializeField]
    private GameObject jewelleryDisplayBoxWindow;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private TouchInput _touchInput;

    private bool _isComplete;

    private void Awake()
    {
        ValuePerPiece();     
    }

    private void ValuePerPiece()
    {
        scoreValue.SetValue( 100f/ (float)noOfJewelleryPieces);
    }

    public void CalculateScore(JewellerPiece.piece anchorType, JewellerPiece.piece jewelleryType)
    {
        //if(anchorProperty.GetAnchorType() == anchorProperty.GetCurrentSelectedPiece())
        if(anchorType == jewelleryType)
        {
            //Debug.Log("scored it");
            var curScore = scoreValue.GetValue();
            var total = totalScore.GetValue();
            totalScore.SetValue(curScore + total);
            //scoreText.text = totalScore.GetValue().ToString();
           
        }
        noOfJewelleryPieces--;
        if (noOfJewelleryPieces <= 0)
        {
            //Debug.Log("jewellery complete");
            _isComplete = true;
        }
        else
        {
            //Debug.Log("jewellery incomplete");
            _isComplete = false;
        }
    }

    public void GoToNextTask()
    {
        if (pendentDesignWindow.activeSelf)
        {
            pendentDesignWindow.SetActive(false);
            jewelleryDisplayBoxWindow.SetActive(true);
            nextButton.SetActive(false);
        }

        else if (_isComplete)
        {
            pendentDesignWindow.SetActive(true);
            jewelleryBox.SetActive(false);
            _touchInput.enabled = false;
        }
        else
        {
            autoFillWindow.SetActive(true);
        }
       
    }

    public void IsComplete()
    {
        //auto fill jwellery
        _isComplete = true;
    }



}
