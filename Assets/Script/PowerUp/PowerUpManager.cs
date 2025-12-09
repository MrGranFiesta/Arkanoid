using UnityEngine;

public class PowerUpManager
{
    private static string[] PowerUps = { Prefab.Ball, Prefab.BigPaddle, Prefab.Life, Prefab.Ball3 };

    public static string GetRamdomPrefab()
    {
        int index = Random.Range(0, PowerUps.Length); 
        return PowerUps[index];
    }
}
