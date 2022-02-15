using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ufo_Destroyer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent Lose_Points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ufo")
        {
            Destroy(collision.gameObject);
            Lose_Points?.Invoke();
        }
    }
}
