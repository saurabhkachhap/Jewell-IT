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
    [SerializeField]
    private GameObject gemBox;
    [SerializeField]
    private GameObject gems;

    [SerializeField]
    private Move pendentDesignWindow;
    [SerializeField]
    private GameObject autoFillWindow;
    [SerializeField]
    private GameObject jewelleryBoxShop;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private TouchInput _touchInput;
    [SerializeField]
    private GameObject undoButton;

    private bool _isComplete;
    [SerializeField]
    private Feedbacks feedbacks;
    private bool _isDisabled = false;
    private BGScript bGScript;
    private TaskDiscription _taskDiscription;
    private Holder _holder;

    private void Awake()
    {
        bGScript = FindObjectOfType<BGScript>();
        _taskDiscription = GetComponent<TaskDiscription>();
        _holder = FindObjectOfType<Holder>();
    }

    public void SetTotalNoOfJewelleryPieces(int count)
    {
        noOfJewelleryPieces = count;
        ValuePerPiece();
    }

    private void ValuePerPiece()
    {
        scoreValue.SetValue( 100f/ (float)noOfJewelleryPieces);
    }

    public void CalculateScore(JewellerPiece.piece anchorType, JewellerPiece.piece jewelleryType)
    {
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
            bGScript.ChangeBgColor(3);
            jewelleryBoxShop.SetActive(true);
            _holder.gameObject.SetActive(false);
            pendentDesignWindow.gameObject.SetActive(false);
            nextButton.SetActive(false);
            _taskDiscription.SetTaskDiscription();
        }

        if (_isComplete)
        {
            gems.SetActive(false);
            gemBox.SetActive(false);
   
            bGScript.ChangeBgColor(2);
            _taskDiscription.SetTaskDiscription();
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
