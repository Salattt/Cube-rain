using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : SpawnebleObject
{
    private bool _isDestroyed = false;

    public event Action<Cube> AlmostDestroyed;

    public void Destroy()
    {
        if(_isDestroyed == false) 
        { 
            _isDestroyed = true;

            ChangeColor();
            StartCoroutine(DestroyRoutine());
        }
    }

    public override void ReturnToDefault()
    {
        _isDestroyed = false;
        _meshRenderer.material.color = _color;
    }

    private void ChangeColor()
    {
        _meshRenderer.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(DestroyTime);

        AlmostDestroyed?.Invoke(this);
        InvokeDestroy();
    }
}
