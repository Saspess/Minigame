using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Drop : Drops
{
    [SerializeField]
    private int _hillPoints = 1;
    [SerializeField]
    private float _energyBoost = 0.1f;

    private Score_Mananger _score_Mananger;
    private Gun_Controler _gun;


    void Start()
    {
        _score_Mananger = FindObjectOfType<Score_Mananger>();
        _gun = FindObjectOfType<Gun_Controler>();
    }
    void Update()
    {
        Move();
    }

    protected override void Activate_Boost()
    {
        _gun.Receive_Energy_Boost(_energyBoost);
        Destroy(gameObject);
        Spawn_Particles();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
