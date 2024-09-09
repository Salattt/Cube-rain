using System;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public abstract class SpawnebleObject : MonoBehaviour
{
    protected MeshRenderer _meshRenderer;
    protected Color _color;

    public event Action<SpawnebleObject> Destroyed;

    public float DestroyTime { get; private set; } = -1;
    public GameObject GameObject { get; private set; }
    public Transform Transform { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        GameObject = gameObject;
        Transform = transform;
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = _meshRenderer.material.color;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Construct(float destoyTime)
    {
        DestroyTime = destoyTime;
    }

    public abstract void ReturnToDefault();

    protected void InvokeDestroy()
    {
        Destroyed?.Invoke(this);
    }
}
