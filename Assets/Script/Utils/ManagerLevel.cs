using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLevel : MonoBehaviour
{
    public static string GetLevel(int level)
    {
        switch (level)
        {
            case 1: return Scene.Lv1;
            case 2: return Scene.Lv2;
            case 3: return Scene.Lv3;
            case 4: return Scene.Lv4;
            case 5: return Scene.Lv5;
            default: return Scene.Menu;
        }
    }
}
