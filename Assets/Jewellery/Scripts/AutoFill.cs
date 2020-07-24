using UnityEngine;
using UnityEngine.AddressableAssets;

public class AutoFill : MonoBehaviour
{
    private Anchor[] _anchorTransform;
    private ScoreManager _scoreManager;
    private Holder _holder;
    private Level _currentLevel;


    private void Awake()
    {
        _holder = FindObjectOfType<Holder>();
        _scoreManager = GetComponent<ScoreManager>();
        var levelManager = FindObjectOfType<LevelManager>();
        _currentLevel = levelManager.GetCurrentLevel();
    }

    public void EnableAutoFill()
    {
        var _anchorPointholder = FindObjectOfType<AnchorPointsHolder>();
        _anchorTransform = _anchorPointholder.GetComponentsInChildren<Anchor>();

        foreach (var item in _anchorTransform)
        {
            if (item.gameObject.activeSelf)
            {
                //pick a random jewell 
                var index = Random.Range(0, _currentLevel.jewelleryPieces.Length);
                var instantiatedJewell = Addressables.InstantiateAsync(_currentLevel.jewelleryPieces[index].Prefab, _holder.transform);

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
