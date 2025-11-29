using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static int _life = 113;
    private static int _point = 6523474;
    private static int _level = 1;
    private static float _time = 547;
    //Controla si el jugador a lanzado la bola
    private static bool _isStartParty = false;

    public static int Life
    {
        get { return _life; }
    }

    public static int Point
    {
        get { return _point; }
    }

    public static int Level
    {
        get { return _level; }
    }

    public static bool IsStartParty
    {
        get { return _isStartParty; }
        set { _isStartParty = value; }
    }

    public static float Time
    {
        get { return _time; }
        set { _time = value; }
    }

    //Observables para produccir eventos
    public static UnityEvent<int> OnPointChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnLifeChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnLevelChanged = new UnityEvent<int>();
  
    //Suma vida
    public static void plusLife()
    {
        //Max 10
        if(_life < 10) { 
            _life++;
            OnLifeChanged.Invoke(_life);
        }
    }

    //Resta vida
    public static void minusLife()
    { 
        _life--;
        OnLifeChanged.Invoke(_life);
        if (_life == 0)
        {
            //Si pierdes aparece la pantalla de GameOver
            _isStartParty = false;
            SceneManager.LoadScene(Scene.GameOver);
        }
    }

    //Pasa al siguiente nivel
    public static void nextLevel()
    {
        _level++;
        OnLevelChanged.Invoke(_level);
        //Resetea si el juegador a lanzado la bola
        IsStartParty = false;
        SceneManager.LoadScene(ManagerLevel.GetLevel(_level));
    }

    //Suma puntos
    public static void AddPoint(int point)
    {
        _point += point;
        OnPointChanged.Invoke(_point);
    }

    //Resetea
    public static void Reset()
    {
        _life = 3;
        _point = 0;
        _level = 1;
        _time = 0;
        _isStartParty = false;
    }
}
