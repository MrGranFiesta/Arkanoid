using UnityEngine.SceneManagement;

public class Player 
{
    private int _life = 3;
    private int _point = 0;
    private float _time = 0;
    private int _level = 1;
    private int _blocksCache = 0;
    private int _ballsCache = 0;
    private static bool _isStartParty = false;

    #region Metodos Level
    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            GameManager.Instance.EventManager.OnLevelChanged?.Invoke(_level);
        }
    }

    public void NextLevel()
    {
        Level++;
        SceneManager.LoadScene(ManagerLevel.GetLevel(Level));
    }

    #endregion
    #region Metodos Life
    public int Life
    {
        get { return _life; }
        set
        {
            _life = value;
            GameManager.Instance.EventManager.OnLifeChanged?.Invoke(_life);
        }
    }

    public void plusLife()
    {
        if (Life < 10)
        {
            Life++;
        }
    }

    public void MinusLife()
    {
        Life--;
        if (Life == 0)
        {
            IsStartParty = false;
            SceneManager.LoadScene(Scene.GameOver);
        }
    }
    #endregion
    #region Metodos Point
    public int Point
    {
        get { return _point; }
        set
        {
            _point = value;
            GameManager.Instance.EventManager.OnPointChanged?.Invoke(_point);
        }
    }

    public void AddPoint(int point)
    {
        Point += point;
    }
    #endregion
    #region Metodos Time
    public float Time
    {
        get { return _time; }
        set
        {
            _time = value;
            GameManager.Instance.EventManager.OnTimeChanged?.Invoke(_time);
        }
    }
    #endregion
    #region Metodos isStartParty
    public bool IsStartParty
    {
        get { return _isStartParty; }
        set { _isStartParty = value; }
    }
    #endregion
    #region Metodo _blocksCache
    public void RegisterBlock()
    {
        _blocksCache++;
    }

    public void DeleteBlock()
    {
        _blocksCache--;
        if (_blocksCache == 0)
        {
            IsStartParty = false;
            NextLevel();
        }
    }
    #endregion
    #region Metodo _ballsCache
    public void RegisterBall()
    {
        _ballsCache++;
    }

    public void DeleteBall()
    {
        _ballsCache--;
    }

    public int GetBallsCache()
    {
        return _ballsCache;
    }
    #endregion
    public void Reset()
    {
        Life = 3;
        Point = 0;
        Level = 1;
        Time = 0;
        _ballsCache = 0;
        _blocksCache = 0;
        IsStartParty = false;
    }
}
