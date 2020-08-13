using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    ParticleSystem _system;
    ParticleSystem.Particle[] _particles;
    [SerializeField]
    private GameObject destination;
    [SerializeField]
    private GameObject cashPrefab;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LeanTweenType tweenType;

    float[] m_times;

    private void OnEnable()
    {
        //_rect = GetComponent<RectTransform>();
        _system = GetComponent<ParticleSystem>();
        m_times = new float[_system.main.maxParticles];
        if (_particles == null || _particles.Length < _system.main.maxParticles)
            _particles = new ParticleSystem.Particle[_system.main.maxParticles];
        
    }

    private void LateUpdate()
    {
        var noOfParticleAlive = _system.GetParticles(_particles);
        for (int i = 0; i < noOfParticleAlive; ++i)
        {
            if (m_times[i] > _particles[i].remainingLifetime && _particles[i].remainingLifetime <= 0.1f)
            {
                // Birth
                Move(_particles[i]);
            }

            m_times[i] = _particles[i].remainingLifetime;

        }
    }


    public void Move(ParticleSystem.Particle particle)
    {
       
        //for (int i = 0; i < noOfParticleAlive; i++)
        {
            var cash = Instantiate(cashPrefab, particle.position, Quaternion.identity);
            cash.transform.SetParent(transform);
            cash.transform.localScale = Vector3.one;
            cash.transform.localRotation = Quaternion.identity;

            LeanTween.move(cash, destination.transform.position, 0.5f).setEase(tweenType);
            //yield return new WaitForSeconds(0.2f);
        }
    }

   


}
