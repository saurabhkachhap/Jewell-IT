using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform jwellerySpawnPoint;
    //[SerializeField]
    //private Transform pendentSpawnPoint;
    [SerializeField]
    private Transform designSpawnPoint;
    [SerializeField]
    private GameObject cashVfx;
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private Transform anchorSpawnPoint;

    private LevelManager _levelManager;
    private List<GameObject> assetsInMemory;
    private float _offset = 0.3f;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        assetsInMemory = new List<GameObject>();
    }

    private void OnEnable()
    {
        SpawnDesign();
        //SpawnJwellPieces();
        //SpawnAnchor();
        //SpawnPendent();
        
    }

    public void SpawnJwellPieces()
    {
        container.SetActive(true);
        var totalJeweleryPiece = _levelManager.GetCurrentLevel().jewelleryPieces.Length;
        for (int i = 0; i < totalJeweleryPiece; i++)
        {
            var quantity = _levelManager.GetCurrentLevel().jewelleryPieces[i].quantity;
            //Debug.Log(quantity);
            for (int j = 0; j <= quantity; j++)
            {
                Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().jewelleryPieces[i].Prefab, jwellerySpawnPoint).Completed += g =>
                {
                    if (g.Status == AsyncOperationStatus.Succeeded)
                    {
                        //var result = g.Result;
                        g.Result.transform.position = new Vector3(jwellerySpawnPoint.position.x + Random.Range(-_offset, _offset),
                                                                    jwellerySpawnPoint.position.y,
                                                                    jwellerySpawnPoint.position.z + Random.Range(-_offset, _offset));
                        assetsInMemory.Add(g.Result);
                    }
                };
                
            }
        }
        
    }

    public void SpawnAnchor()
    {
        var g = Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().anchorPoints, anchorSpawnPoint);
        assetsInMemory.Add(g.Result);       
    }

    private void SpawnDesign()
    {
        var g = Addressables.InstantiateAsync(_levelManager.GetCurrentLevel().jewelleryDesign, designSpawnPoint);
        assetsInMemory.Add(g.Result);
    }

    public void RemoveAssetFromMemory()
    {
        StartCoroutine(nameof(RemoveAsset));
    }

    private IEnumerator RemoveAsset()
    {
        cashVfx.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        foreach (var item in assetsInMemory)
        {
            Addressables.ReleaseInstance(item);
        }
        yield return new WaitForEndOfFrame();
        _levelManager.ResetLevel();
    }

}
