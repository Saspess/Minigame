using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubin_Drop : Drops
{
    [SerializeField]
    private float _boostPoints = 0.1f;

    private Ufo_Spawner _ufo_Spawner;

    void Start()
    {
        _ufo_Spawner = FindObjectOfType<Ufo_Spawner>();
    }

    void Update()
    {
        Move();
    }

    protected override void Activate_Boost()
    {
        _ufo_Spawner.Receive_Boost(_boostPoints);
        Destroy(gameObject);
        Spawn_Particles();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
