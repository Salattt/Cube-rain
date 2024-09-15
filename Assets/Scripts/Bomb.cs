using System.Collections;
using UnityEngine;

public class Bomb : SpawnebleObject
{
    [SerializeField] private Explosion _explosion;

    public override void ReturnToDefault()
    {
        _meshRenderer.material.color = _color;    
    }

    public override void Construct(float destoyTime)
    {
        base.Construct(destoyTime);

        StartCoroutine(DestroyRoutine());
    }

    private IEnumerator DestroyRoutine()
    {
        float timer = DestroyTime;
        WaitForSeconds updateTime = new WaitForSeconds(Time.fixedDeltaTime);

        while (timer > 0)
        { 
            yield return updateTime;

            timer -= Time.fixedDeltaTime;

            _meshRenderer.material.color = new Color(_color.r, _color.g, _color.b,timer/DestroyTime);
        }

        _explosion.Explode();

        InvokeDestroy();
    }
}
