using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _ufo;
    [SerializeField]
    private GameObject _shotableUfo;
    [SerializeField]
    private float _spawnRate = 2.0f;
    [SerializeField]
    private float _minY;
    [SerializeField]
    private float _maxY;
    private float _randY;
    float _nextSpawn = 0.0f;
    Vector2 _spawnPoint;

    private void Start()
    {
        _spawnRate = 2.0f;
    }

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + _spawnRate;
            _randY = Random.Range(_minY, _maxY);
            _spawnPoint = new Vector2(transform.position.x, _randY);
            Instantiate(_ufo, _spawnPoint, Quaternion.identity);
        }
    }

    public void OnSpawnRate()
    {
        if(_spawnRate >= 0.5f)
        {
            _spawnRate -= 0.2f;
        }
        Instantiate(_shotableUfo, _spawnPoint, Quaternion.identity);
    }

    public void Receive_Boost(float _time)
    {
        if (_spawnRate <= 2.0f)
        {
            _spawnRate += _time;
        }
    }
}
