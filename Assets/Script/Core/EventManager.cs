using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public UnityEvent<int> OnPointChanged = new UnityEvent<int>();
    public UnityEvent<int> OnLifeChanged = new UnityEvent<int>();
    public UnityEvent<int> OnLevelChanged = new UnityEvent<int>();
    public UnityEvent<float> OnTimeChanged = new UnityEvent<float>();
}
