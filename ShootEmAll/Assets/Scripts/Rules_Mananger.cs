using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Rules_Mananger : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvas1;
    [SerializeField]
    private GameObject _canvas2;

    public void Show_Canvas_1()
    {
        _canvas1.SetActive(false);
        _canvas2.SetActive(true);
    }

    public void Show_Canvas_2()
    {
        _canvas2.SetActive(false);
        _canvas1.SetActive(true);
    }
}
