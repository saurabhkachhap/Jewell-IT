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
    private Move pendentDesignWindow;
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
    [SerializeField]
    private GameObject undoButton;

    private bool _isComplete;
    [SerializeField]
    private Feedbacks feedbacks;
    private bool _isDisabled;

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
            //add feadback for player here
            if (!_isDisabled)
            {
                feedbacks.GiveFeedback();
            }          
           
        }
        noOfJewelleryPieces--;
        if (noOfJewelleryPieces <= 0)
        {
            //Debug.Log("jewellery complete");
            undoButton.SetActive(false);
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
        if (pendentDesignWindow.enabled && _isComplete)
        {
            //pendentDesignWindow.SetActive(false);
            jewelleryDisplayBoxWindow.SetActive(true);
            pendentDesignWindow.gameObject.SetActive(false);
            nextButton.SetActive(false);
        }

        if (_isComplete)
        {
            //pendentDesignWindow.enabled = true;
            //jewelleryBox.SetActive(false);
            pendentDesignWindow.enabled = true;
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
        undoButton.SetActive(false);
    }

    public void DisableFeedBack()
    {
        _isDisabled = true;
    }



}
