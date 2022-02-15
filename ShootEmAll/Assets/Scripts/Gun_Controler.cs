using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controler : MonoBehaviour
{
    [SerializeField]
    private int _speed = 1;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shotPoint;
    [SerializeField]
    private float _startTimeBtwAttack;

    private float _timeBtwAttack;

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
        }

        if (Input.GetKey("space"))
        {
            Shoot();
        }
    }
    private void Move()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(transform.position.x, -8.0f, 8.0f), transform.position.y) + direction, _speed * Time.deltaTime);
    }

    private void Shoot()
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

    public void Receive_Energy_Boost(float _time)
    {
        if(_startTimeBtwAttack >= 0.2)
        {
            _startTimeBtwAttack -= _time;
        }    
    }
}
