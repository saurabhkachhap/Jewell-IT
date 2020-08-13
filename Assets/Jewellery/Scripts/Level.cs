using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Level_", menuName = "Create New Level")]
public class Level : ScriptableObject
{
    public JewelleryPieces[] jewelleryPieces;
    [Space]
    public AssetReferenceGameObject pendents;
    [Space]
    public AssetReferenceGameObject anchorPoints;
    [Space]
    public AssetReferenceGameObject jewelleryDesign;
    public int totalReward;
}
