using UnityEngine;

public class SvedObject
{
    private static Anchor hitObject;

    public static void SetTransformProperty(Anchor obj)
    {
        hitObject = obj;
    }

    public static Anchor GetHitObject()
    {
        return hitObject;
    }
}
