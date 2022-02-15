using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 0;
    [SerializeField]
    protected float _minSpeed;
    [SerializeField]
    protected float _maxSpeed;
    [SerializeField]
    protected ParticleSystem _particles;
    [SerializeField]
    protected int _scorePoints = 1;
    [SerializeField]
    protected int _health = 1;
    [SerializeField]
    protected Hill_Drop _hillDrop;
    [SerializeField]
    protected Energy_Drop _energyDrop;
    [SerializeField]
    protected Rubin_Drop _rubinDrop;


    private int _rand_Boost;
    protected Score_Mananger _score_Mananger;

    private void Start()
    {
        _score_Mananger = FindObjectOfType<Score_Mananger>();
        _speed = Random.Range(_minSpeed + _speed, _maxSpeed + _speed);
        _rand_Boost = Random.Range(0, 100);
    }

    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        Vector3 direction = transform.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
    }

    protected virtual void Receive_Damage()
    {
        _health--;
        if(_health <= 0)
        {
            if(_rand_Boost > 0 && _rand_Boost <= 3)
            {
                Instantiate(_hillDrop, transform.position, Quaternion.identity);
            }
            if (_rand_Boost > 10 && _rand_Boost <= 13)
            {
                Instantiate(_energyDrop, transform.position, Quaternion.identity);
            }
            if (_rand_Boost > 20 && _rand_Boost <= 30)
            {
                Instantiate(_rubinDrop, transform.position, Quaternion.identity);
            }
            Instantiate(_particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _score_Mananger.OnScore(_scorePoints);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Receive_Damage();
        }
    }
}
