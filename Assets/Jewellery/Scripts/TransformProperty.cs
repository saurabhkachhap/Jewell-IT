using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Transform Property", menuName ="New Transform Property")]
public class TransformProperty : ScriptableObject
{
    [SerializeField]
    private Vector3Variable position;
    public Quaternion rotation;
    private GameObject hitObject;
    public bool isAttachToAnchor = false;
    public JewellerPiece.piece anchorType;
    public JewellerPiece.piece currentSelectedPiece;
    //public Collider collider;

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

    public void SetTransformProperty(GameObject obj)
    {
        hitObject = obj;      
    }

    public GameObject GetHitObject()
    {
        return hitObject;
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
