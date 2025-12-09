using UnityEngine;

//Agrega una vida
public class Life : MonoBehaviour, IPowerUpType
{
    public void Apply(Paddle paddle)
    {
        GameManager.Instance.Player.plusLife();
    }
}
