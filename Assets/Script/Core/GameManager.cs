using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { get; private set; }
    public Player Player { set; get; } = new Player();
    public EventManager EventManager { set; get; } = new EventManager();
    

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("GameManager");
            Instance = go.AddComponent<GameManager>();
            DontDestroyOnLoad(go);
        }
    }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
