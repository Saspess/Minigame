using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill_Drop : Drops
{
    [SerializeField]
    private int _hillPoints = 1;

    private Score_Mananger _score_Mananger;
    
    void Start()
    {
        _score_Mananger = FindObjectOfType<Score_Mananger>();
    }

    void Update()
    {
        Move();
    }

    protected override void Activate_Boost()
    {
        _score_Mananger.Receive_Hill_Boost();
        Destroy(gameObject);
        Spawn_Particles();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
