using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Block", order = 1)]
public class BlockData : ScriptableObject
{
    public int life;
    public int point;
    public Color color;
    public int percentSpawnerPowerUp;
}