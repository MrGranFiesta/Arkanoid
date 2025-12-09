using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Actual PowerUp
    private IPowerUpType currentPowerUp;

    //Inicia en una corrutina el powerUp
    public void StartPowerUp(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        currentPowerUp = collision.gameObject.GetComponent<IPowerUpType>();
        if (currentPowerUp != null)
        {
            currentPowerUp.Apply(this);
            Destroy(collision.gameObject);
        }
    }

    //Resetea la pala y el power up aplicado
    public void ResetPaddleAndPowerUp()
    {
        transform.position = GameConstants.PositionPaddleOrigin;
        currentPowerUp?.Reset();
    }
}
