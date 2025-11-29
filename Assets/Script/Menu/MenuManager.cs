using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Carga el LV 1 y resete el GameManager
    public void StartedGame()
    {
        GameManager.Reset();
        SceneManager.LoadScene(Scene.Lv1);
    }

    //Vuelve al menu principal
    public void NavigateToMenuScreem()
    {
        SceneManager.LoadScene(Scene.Menu);
    }
}
