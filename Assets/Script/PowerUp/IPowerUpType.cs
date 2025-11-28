using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUpType {
    public void Apply(Paddle paddle);
    public void Reset()
    {
        //NOTHING TO DO
    }
}
