using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    private SphereCollider _sphereCollider;
    private Transform _transform;

    public void Awake()
    {
        _transform = transform;
    }

    public void Explode()
    {
        RaycastHit[] hits = Physics.SphereCastAll(_transform.position,_radius,Vector3.one, float.Epsilon);

        if(hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)
            {
                if(hit.rigidbody != null)
                    hit.rigidbody.AddForce((hit.transform.position - _transform.position).normalized * _force,ForceMode.Impulse);
            }
        }
    }
}
