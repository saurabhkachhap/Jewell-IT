using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UndoBooster : MonoBehaviour
{
    private int noOfBostersLeft = 2;
    [SerializeField]
    private TextMeshProUGUI boosterCount;
    //private Dictionary<GameObject,Vector3> _history = new Dictionary<GameObject, Vector3>();
    private List<ArrayList> _history = new List<ArrayList>();

    private void Awake()
    {
        boosterCount.text = noOfBostersLeft.ToString();
    }

    public void AddToHistory(GameObject lastObj, Vector3 pos, GameObject anchor)
    {
        //var anchor = SvedObject.GetHitObject().gameObject;
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
            boosterCount.text = noOfBostersLeft.ToString();
            _history.Remove(lastIndex);
        }
        
    }
}
