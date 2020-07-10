using UnityEngine;

public class AnchorPointsHolder : MonoBehaviour
{
    private ScoreManager _scoreManager;
    //[SerializeField]
    //private Vector3 pendentSpawnPos;
    //[SerializeField]
    //private GameObject pendentAnchor;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        var count = transform.childCount;
        _scoreManager.SetTotalNoOfJewelleryPieces(count - 1);
    }
}
