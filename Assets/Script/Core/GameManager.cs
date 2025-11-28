using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager
{
    private int _life = 3;
    private int _point = 0;
    private int _level = 1;
    private static bool isStartParty = false;

    public int Life
    {
        get { return _life; }
    }

    public int Point
    {
        get { return _point; }
    }

    public int Level
    {
        get { return _level; }
    }

    public static bool IsStartParty
    {
        get { return isStartParty; }
        set { isStartParty = value; }
    }

    public static UnityEvent<int> OnPointChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnLifeChanged = new UnityEvent<int>();
    public static UnityEvent<int> OnLevelChanged = new UnityEvent<int>();
  
    public void plusLife()
    {
        if(_life < 10) { 
            _life++;
            OnLifeChanged.Invoke(_life);
        }
    }

    public void minusLife()
    { 
        _life--;
        OnLifeChanged.Invoke(_life);
        if (_life == 0)
        {
            GameManager.IsStartParty = false;
            SceneManager.LoadScene(Scene.GameOver);
        }
    }

    public void nextLevel()
    {
        _level++;
        OnLevelChanged.Invoke(_level);
        IsStartParty = false;
        SceneManager.LoadScene(ManagerLevel.GetLevel(_level));
    }

    public void AddPoint(int point)
    {
        _point += point;
        OnPointChanged.Invoke(_point);
    }
}
