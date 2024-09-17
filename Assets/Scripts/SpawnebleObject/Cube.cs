using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : SpawnebleObject
{
    private bool _isDestroyed = false;
    private WaitForSeconds _destroyTime;


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
        MeshRenderer.material.color = StartColor;
    }

    private void ChangeColor()
    {
        MeshRenderer.material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    private IEnumerator DestroyRoutine()
    {
        _destroyTime = new WaitForSeconds(DestroyTime);

        yield return _destroyTime;

        AlmostDestroyed?.Invoke(this);
        InvokeDestroy();
    }
}
