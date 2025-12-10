using UnityEngine;

//Agrega una vida
public class Life : MonoBehaviour, IPowerUpType
{
    public void Apply(Paddle paddle)
    {
        GameManager.Instance.AudioManager.PlaySound(Resources.Load<AudioClip>("Sounds/Regeneration"));
        GameManager.Instance.Player.plusLife();
    }
}
