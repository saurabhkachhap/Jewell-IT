using UnityEngine;

public class ShockWave : MonoBehaviour
{
    //private Vector3Variable posContainer;
    [SerializeField]
    private float intensity = 3f;

    public void Explode(Vector3 explosionPos)
    {
        Collider[] collider = Physics.OverlapSphere(explosionPos, 0.25f); 
        foreach (var hit in collider)
        {
            var rb = hit.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(intensity, explosionPos, 0.5f, 0.25f,ForceMode.Impulse);
                //Debug.Log("explosion");
            }
        }
    }
}
