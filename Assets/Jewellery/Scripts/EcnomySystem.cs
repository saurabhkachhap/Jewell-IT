using System;
using TMPro;
using UnityEngine;

public class EcnomySystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cashText;
    private LevelManager _levelManager;
    [SerializeField]
    private TextMeshProUGUI rewardText;

    private int _totalCash;
    private readonly string[] suffixes = { "", "k", "M", "G" };

    private void Awake()
    {
        _totalCash = PlayerPrefs.GetInt("cash", 3000);
        cashText.text = PrettyCurrency(_totalCash);
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void CalculateReward(FloatVariable score)
    {
        var totalRewardValue = _levelManager.GetCurrentLevel().totalReward;
        var accurecyPoints = score.GetValue();
        var calculatedReward = Mathf.RoundToInt(totalRewardValue * accurecyPoints / 100);
        _totalCash += calculatedReward;
        rewardText.text = "+" + calculatedReward.ToString();
    }

    public void AddMoney()
    {
        cashText.text = PrettyCurrency(_totalCash);
        PlayerPrefs.SetInt("cash", _totalCash);
        PlayerPrefs.Save();
    }

    public void DeductMoney(int amount)
    {
        _totalCash -= amount;
        cashText.text = PrettyCurrency(_totalCash);  
    }

    private string PrettyCurrency(long cash/*, string prefix = "$"*/)
    {
        int k;
        if (cash == 0)
            k = 0;    // log10 of 0 is not valid
        else
            k = (int)(Math.Log10(cash) / 3); // get number of digits and divide by 3
        var dividor = Math.Pow(10, k * 3);  // actual number we print
        var text = /*prefix +*/ (cash / dividor).ToString("F1") + suffixes[k];
        return text;
    }




}
