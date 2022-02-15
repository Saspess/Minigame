using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Controler : MonoBehaviour
{
    [SerializeField]
    protected GameObject _Canvas;

    public void Pause_On()
    {
        Time.timeScale = 0;
        _Canvas.SetActive(true);
    }

    public void Pause_Off()
    {
        Time.timeScale = 1;
        _Canvas.SetActive(false);
    }
}
