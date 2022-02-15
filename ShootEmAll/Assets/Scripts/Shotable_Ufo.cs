using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotable_Ufo : Ufo
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shotPoint;
    [SerializeField]
    private float _startTimeBtwAttack;

    private float _timeBtwAttack;
    private Gun_Controler _gun;

    private void Start()
    {
        _score_Mananger = FindObjectOfType<Score_Mananger>();
        _speed = Random.Range(_minSpeed + _speed, _maxSpeed + _speed);
        _gun = FindObjectOfType<Gun_Controler>();
    }

   private void Update()
    {
        Move();
        Shoot();
    }

    protected void Shoot() 
    {
        if (_timeBtwAttack <= 0)
        {
            Instantiate(_bullet, _shotPoint.position, Quaternion.identity);
            _timeBtwAttack = _startTimeBtwAttack;
        }
        else
        {
            _timeBtwAttack -= Time.deltaTime;
        }
    }
}
