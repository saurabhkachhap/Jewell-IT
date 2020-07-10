using UnityEngine;

[CreateAssetMenu(fileName = "Jewellery Piece", menuName = "New Jewellery Piece")]
public class JewellerPiece : ScriptableObject
{
    public enum piece
    {
        None,
        Sphear,
        Heart,
        Square,
        Gem,
        Hex,
        Diamond
    }

    public piece pieceType = piece.None;

}
