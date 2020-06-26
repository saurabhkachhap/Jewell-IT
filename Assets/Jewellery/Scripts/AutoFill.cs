using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFill : MonoBehaviour
{
    [SerializeField]
    private Transform anchor;
    [SerializeField]
    private Transform[] jewellPieces;
    private List<Transform> _anchors;
    private ScoreManager _scoreManager;
    private Holder _holder;

    private void Awake()
    {
        _holder = FindObjectOfType<Holder>();
        _scoreManager = GetComponent<ScoreManager>();
        _anchors = new List<Transform>();

        foreach (Transform child in anchor)
        {
            _anchors.Add(child);
        }
    }

    public void EnableAutoFill()
    {
        foreach (var item in _anchors)
        {
            if (item.gameObject.activeSelf)
            {
                //pick a random jewell
                var index = Random.Range(0, jewellPieces.Length);
                //instanctiate and place it on item transform
                var anchorType = item.GetComponent<Anchor>().anchorType;
                item.gameObject.SetActive(false);
                var randomJwell = Instantiate(jewellPieces[index], item.transform.position, item.transform.rotation);
                randomJwell.SetParent(_holder.transform);
                var jwellType = randomJwell.GetComponent<RayCaster>().jewellerPiece;
                randomJwell.GetComponent<Rigidbody>().isKinematic = true;

                if(anchorType == jwellType)
                {
                    _scoreManager.CalculateScore(anchorType.pieceType, jwellType.pieceType);
                    _scoreManager.IsComplete();
                }

            }
        }
    }
}
