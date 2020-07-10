using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AutoFill : MonoBehaviour
{
    //[SerializeField]
    //private Transform anchor;
    [SerializeField]
    private AssetReferenceGameObject[] jewellPieces;
    private Anchor[] _anchorTransform;
    private ScoreManager _scoreManager;
    private Holder _holder;
    //private GameObject _anchorPoints;
    //private AnchorPointsHolder _anchorPointholder;

    private void Awake()
    {
        _holder = FindObjectOfType<Holder>();
        _scoreManager = GetComponent<ScoreManager>();
       
    }

    public void EnableAutoFill()
    {
        var _anchorPointholder = FindObjectOfType<AnchorPointsHolder>();
        //var anchor = _anchorPointholder.transform;
        //_anchorTransform = new List<Transform>();
        _anchorTransform = _anchorPointholder.GetComponentsInChildren<Anchor>();

        //foreach (Transform child in anchor)
        //{
        //    anchor.GetComponent<Anchor>();
        //    _anchorTransform.Add(child);
        //}
        foreach (var item in _anchorTransform)
        {

            if (item.gameObject.activeSelf)
            {
                //pick a random jewell 
                var index = Random.Range(0, jewellPieces.Length);
                var instantiatedJewell = Addressables.InstantiateAsync(jewellPieces[index], _holder.transform);

                var newJewell = instantiatedJewell.Result;
                newJewell.transform.position = item.transform.position;
                newJewell.transform.rotation = item.transform.rotation;

                var jwellType = newJewell.GetComponent<RayCaster>().jewellerType;
                newJewell.GetComponent<Rigidbody>().isKinematic = true;
                var anchorObj = item.GetComponent<Anchor>();
                {
                    if (anchorObj)
                    {
                        var anchorType = anchorObj.anchorType;
                        item.gameObject.SetActive(false);

                        if (anchorType == jwellType)
                        {
                            _scoreManager.CalculateScore(anchorType.pieceType, jwellType.pieceType);
                            _scoreManager.IsComplete();
                        }
                    }
                }
            }
        }
    }
}
