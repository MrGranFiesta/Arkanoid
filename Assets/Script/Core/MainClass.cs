using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClass : MonoBehaviour
{
    private static GameManager gameManager;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Main()
    {
        gameManager = new GameManager();
        GameObject go = new GameObject();
        DontDestroyOnLoad(go);
    }

    public static GameManager getGameManager()
    {
        return gameManager;
    }
}
