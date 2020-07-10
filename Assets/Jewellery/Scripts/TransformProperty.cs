using UnityEngine;

[CreateAssetMenu(fileName ="Transform Property", menuName ="New Transform Property")]
public class TransformProperty : ScriptableObject
{
    [SerializeField]
    private Vector3Variable position;
    [SerializeField]
    private Quaternion rotation;
    [SerializeField]
    private bool isAttachToAnchor = false;
    [SerializeField]
    private JewellerPiece.piece anchorType;
    [SerializeField]
    private JewellerPiece.piece currentSelectedPiece;

    public void SetTransformProperty(Vector3 pos, Quaternion rot, bool flag)
    {
        position.SetValue(pos);
        rotation = rot;
        isAttachToAnchor = flag;
    }

    public void SetTransformProperty(bool flag)
    {
        isAttachToAnchor = flag;
    }
    
    public (Vector3,Quaternion,bool) GetTransformProperty()
    {
        return (position.GetValue(),rotation,isAttachToAnchor);
    }


    public void SetAnchorType(JewellerPiece.piece piece)
    {
        anchorType = piece;
    }

    public JewellerPiece.piece GetAnchorType()
    {
        return anchorType;
    }

    public void SetCurrentSelectedPiece(JewellerPiece.piece piece)
    {
        currentSelectedPiece = piece;
    }

    public JewellerPiece.piece GetCurrentSelectedPiece()
    {
        return currentSelectedPiece;
    }

}
