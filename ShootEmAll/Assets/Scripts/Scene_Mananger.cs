using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Mananger : MonoBehaviour
{
    public void Next_Scene(int _scene)
    {
        SceneManager.LoadScene(_scene);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
