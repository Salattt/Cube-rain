using System.Collections;
using UnityEngine;

public class Bomb : SpawnebleObject
{
    [SerializeField] private Explosion _explosion;

    private WaitForSeconds _updateTime;

    private void Start()
    {
        _updateTime = new WaitForSeconds(Time.fixedDeltaTime);
    }

    public override void ReturnToDefault()
    {
        MeshRenderer.material.color = StartColor;    
    }

    public override void Construct(float destoyTime)
    {
        base.Construct(destoyTime);

        StartCoroutine(DestroyRoutine());
    }

    private IEnumerator DestroyRoutine()
    {
        float timer = DestroyTime;

        while (timer > 0)
        { 
            yield return _updateTime;

            timer -= Time.fixedDeltaTime;

            MeshRenderer.material.color = new Color(StartColor.r, StartColor.g, StartColor.b,timer/DestroyTime);
        }

        _explosion.Explode();

        InvokeDestroy();
    }
}
