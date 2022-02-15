using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : Bullet
{
    protected Score_Mananger _score_Mananger;

    private Gun_Controler _gun;
    private Vector3 _pos;

    void Start()
    {
        _score_Mananger = FindObjectOfType<Score_Mananger>();
        _gun = FindObjectOfType<Gun_Controler>();
        _pos = _gun.transform.position;
    }

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pos, _speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
            Spawn_Particles();
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Spawn_Particles();
            _score_Mananger.Receive_Damage();
        }
    }
}
