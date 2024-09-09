using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    private SphereCollider _sphereCollider;
    private Transform _transform;

    public void Awake()
    {
        _transform = transform;
        _sphereCollider = GetComponent<SphereCollider>();

        _sphereCollider.radius = _radius;

        _sphereCollider.enabled = false;
    }

    public void Explode()
    {
        _sphereCollider.radius = _radius;
        _sphereCollider.enabled = true;
    }

    public void TurnOff()
    {
        _sphereCollider.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SpawnebleObject spawnebleObject))
        {
            Vector3 direction = spawnebleObject.Transform.position - _transform.position;

            spawnebleObject.Rigidbody.AddForce(direction.normalized * Mathf.Clamp01(1 - (_radius - direction.magnitude) / _radius) * _force, ForceMode.VelocityChange);
        }
    }
}
