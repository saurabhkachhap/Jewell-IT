using UnityEngine;

[RequireComponent(typeof(BezierSpline))]
public class JewelleryDesigner : MonoBehaviour
{
	private BezierSpline _spline;

	private int frequency;

	public bool lookForward = true;

    private void Reset()
    {
		if (!_spline)
        {
			_spline = GetComponent<BezierSpline>();
		}
		
    }

	

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
}
