using UnityEngine;

public class JewelleryDesigner : MonoBehaviour
{
	public BezierSpline _spline;

	private int frequency;

	public bool lookForward;

    //public Transform[] items;

    public void SpawnGems()
	{
		//if (frequency <= 0 || items == null || items.Length == 0)
		//{
		//	return;
		//}

		frequency = transform.childCount;
		float stepSize = frequency;
		stepSize = 1f / (stepSize - 1);
		
		
		for (int p = 0; p < frequency; p++)
		{
            //for (int i = 0; i < items.Length; i++, p++)
            {
				Transform item = transform.GetChild(p);
				Vector3 position = _spline.GetPoint(p * stepSize);
				item.transform.position = position;
				if (lookForward)
				{
					item.transform.LookAt(position + _spline.GetDirection(p * stepSize));
					//var rot = item.transform.rotation;
					//var newRot = Quaternion.Euler(90f, rot.y, rot.z);
					//item.transform.rotation = newRot;
				}
				//item.transform.parent = transform;
			}
		}
	}

    //private void SetPosition()
    //{
    //    var point = _spline.GetPoint(0f);
    //    var child = _spline.transform.GetChild(0);
    //    child.position = point;

    //    var steps = STEPS_PER_CURVE * _spline.CurveCount;
    //    for (int i = 1; i < steps; i++)
    //    {
    //        point = _spline.GetPoint(i / (float)steps);
    //        child = _spline.transform.GetChild(i);
    //        child.position = point;
    //    }

    //}
}
