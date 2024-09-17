using TMPro;
using UnityEngine;

public class SpawnerViewer<T> : MonoBehaviour where T : SpawnebleObject
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private TextMeshProUGUI _spawnedInfo;
    [SerializeField] private TextMeshProUGUI _activeInfo;
    [SerializeField] private TextMeshProUGUI _instantiateInfo;
    [SerializeField] private Spawner<T> _spawner;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += UpdateActiveInfo;
        _spawner.ObjectSpawned += UpdateSpawnedInfo;
        _pool.ObjectInstantiate += UpdateInstantiateInfo;
        _pool.ObjectReleased += UpdateActiveInfo;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= UpdateActiveInfo;
        _spawner.ObjectSpawned -= UpdateSpawnedInfo;
        _pool.ObjectInstantiate -= UpdateInstantiateInfo;
        _pool.ObjectReleased -= UpdateActiveInfo;
    }

    private void UpdateSpawnedInfo()
    {
        _spawnedInfo.text = _spawner.SpawnQuantity.ToString();
    }

    private void UpdateInstantiateInfo()
    {
        _instantiateInfo.text = _pool.InitiatedObjects.ToString();
    }

    private void UpdateActiveInfo()
    {
        _activeInfo.text = (_spawner.SpawnQuantity - _pool.ReleasedObjects).ToString();
    }
}
