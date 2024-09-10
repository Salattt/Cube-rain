using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectQuantityVisualisator : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private TextMeshProUGUI _spawnedInfo;
    [SerializeField] private TextMeshProUGUI _activeInfo;
    [SerializeField] private TextMeshProUGUI _instantiateInfo;


    private int _spawnedQuantity = 0;
    private int _activeQuantity = 0;
    private int _instantiateQuantity = 0;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += OnObjectSpawned;
        _pool.ObjectInstantiate += OnObjectInstantiate;
        _pool.ObjectReleased += OnObjectReleased;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= OnObjectSpawned;
        _pool.ObjectInstantiate -= OnObjectInstantiate;
        _pool.ObjectReleased -= OnObjectReleased;
    }

    private void OnObjectSpawned()
    {
        _spawnedQuantity++;
        _activeQuantity++;

        _spawnedInfo.text = _spawnedQuantity.ToString();
        _activeInfo.text = _activeQuantity.ToString();
    }

    private void OnObjectInstantiate()
    {
       _instantiateQuantity++;

        _instantiateInfo.text = _instantiateQuantity.ToString();
    }

    private void OnObjectReleased()
    {
        _activeQuantity--;

        _activeInfo.text = _activeQuantity.ToString();
    }
}
