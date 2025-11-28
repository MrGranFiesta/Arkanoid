using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager
{
    public static GameObject GetPrefab(IPowerUpType type) {
        switch (type) {
            case Ball1:
                return Resources.Load<GameObject>(Prefab.Ball);
            case BigPaddle:
                return Resources.Load<GameObject>(Prefab.BigPaddle);
            case Life:
                return Resources.Load<GameObject>(Prefab.Life);
            case Ball3:
                return Resources.Load<GameObject>(Prefab.Ball3);
            default: return null;  
        }
    }
}
