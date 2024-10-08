using System;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
public abstract class SpawnebleObject : MonoBehaviour
{
    protected MeshRenderer MeshRenderer;
    protected Color StartColor;

    public event Action<SpawnebleObject> Destroyed;

    public float DestroyTime { get; private set; } = -1;
    public GameObject GameObject { get; private set; }
    public Transform Transform { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        GameObject = gameObject;
        Transform = transform;
        MeshRenderer = GetComponent<MeshRenderer>();
        StartColor = MeshRenderer.material.color;
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
