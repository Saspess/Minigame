using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drops : Bullet
{

    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        Vector3 direction = -transform.up;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
    }

    protected virtual void Activate_Boost()
    {
        Destroy(gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Activate_Boost();
        }
    }
}
