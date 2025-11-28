using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour, IPowerUpType
{
    public void Apply(Paddle paddle)
    {
        MainClass.getGameManager().plusLife();
    }
}
