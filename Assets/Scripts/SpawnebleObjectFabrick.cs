using UnityEngine;

public class SpawnebleObjectFabrick : MonoBehaviour
{
    [SerializeField] private SpawnebleObject _prefab;

    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    public SpawnebleObject Instantiate()
    {
        return Instantiate(_prefab, _position, Quaternion.identity);
    }
}
