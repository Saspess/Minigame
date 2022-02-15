using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 1.0f;
    [SerializeField]
    protected ParticleSystem _particles;

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 direction = transform.up;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
    }

    protected void Spawn_Particles()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ufo")
        {
            Destroy(gameObject);
            Spawn_Particles();
        }
    }
}
