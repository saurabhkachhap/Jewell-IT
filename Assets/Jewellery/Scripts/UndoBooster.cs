using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UndoBooster : MonoBehaviour
{
    private int noOfBostersLeft = 3;
    [SerializeField]
    private TextMeshProUGUI boosterCount;
    [SerializeField]
    private Image boosterBtn;
    [SerializeField]
    private Sprite disabledSprite;
    private List<ArrayList> _history = new List<ArrayList>();

    private void Awake()
    {
        boosterCount.text = (noOfBostersLeft - 1).ToString();
    }

    public void AddToHistory(GameObject lastObj, Vector3 pos, GameObject anchor)
    {
        _history.Add(new ArrayList { lastObj ,pos ,anchor});
    }

    public void UseBooster(Transform parent)
    {
        if(noOfBostersLeft > 0 && _history.Count > 0)
        {
            var lastIndex = _history[_history.Count - 1];
            var lastPiece = (GameObject)lastIndex[0];
            var position = (Vector3)lastIndex[1];
            var anchor = (GameObject)lastIndex[2];

            lastPiece.transform.position = position;
            anchor.SetActive(true);
            lastPiece.transform.SetParent(parent);
            lastPiece.tag = "Selectable";
            noOfBostersLeft--;
            UpdateText();
            _history.Remove(lastIndex);
            
        }
    }

    private void UpdateText()
    {
        switch (noOfBostersLeft)
        {
            case 3:
                boosterCount.text = "2";
                break;
            case 2:
                boosterCount.text = "1";
                break;
            case 1:
                boosterCount.text = "Free";
                break;
            case 0:
                boosterBtn.sprite = disabledSprite;
                boosterCount.text = "";
                break;
        }
        
    }
}
