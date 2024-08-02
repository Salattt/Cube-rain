using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Color _color;
    private bool _isDestroyed = false;

    public event Action<Cube> Destroyed;

    public GameObject GameObject { get; private set; }
    public Transform Transform { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = _meshRenderer.material.color;
        GameObject = gameObject;
        Transform = transform;
    }

    public void Destroy()
    {
        if(_isDestroyed == false) 
        { 
            _isDestroyed = true;

            Destroyed?.Invoke(this);
            ChangeColor();
        }
    }

    public void ReturnToDefault()
    {
        _isDestroyed = false;
        _meshRenderer.material.color = _color;
    }

    private void ChangeColor()
    {
        _meshRenderer.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
