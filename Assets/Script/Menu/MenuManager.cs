using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartedGame()
    {
        SceneManager.LoadScene(Scene.Lv1);
    }

    public void NavigateToMenuScreem()
    {
        SceneManager.LoadScene(Scene.Menu);
    }
}
