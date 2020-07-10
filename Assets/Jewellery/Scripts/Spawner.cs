using UnityEngine;
using UnityEngine.AddressableAssets;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform jwellerySpawnPoint;
    [SerializeField]
    private Transform pendentSpawnPoint;
    [SerializeField]
    private Transform designSpawnPoint;

    private LevelManager _levelManager;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        SpawnDesign();
        SpawnJwellPieces();
        SpawnAnchor();
        SpawnPendent();
        
    }

    private void SpawnJwellPieces()
    {
        var totalJeweleryPiece = _levelManager.GetCurrentLevel().jewelleryPieces.Length;
        for (int i = 0; i < totalJeweleryPiece; i++)
        {
            var quantity = _levelManager.GetCurrentLevel().jewelleryPieces[i].quantity;
            //Debug.Log(quantity);
            for (int j = 0; j <= quantity; j++)
            {
                Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().jewelleryPieces[i].Prefab, jwellerySpawnPoint);
            }
        }       
    }

    private void SpawnPendent()
    {
        Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().pendents, pendentSpawnPoint);
    }

    private void SpawnAnchor()
    {
        Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().anchorPoints);
    }

    private void SpawnDesign()
    {
        Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().jewelleryDesign, designSpawnPoint);
    }

}
