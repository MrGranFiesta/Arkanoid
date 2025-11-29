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
        //Si colisiona un powerUp lo aplica en el objeto actual para que pueda ejecutarse las corrutinas
        if (collision.gameObject.CompareTag(Tag.PowerUp))
        {
            currentPowerUp = collision.gameObject.GetComponent<IPowerUpType>();
            currentPowerUp.Apply(this);
            
            Destroy(collision.gameObject);
        }
    }

    //Resetea la pala y el power up aplicado
    public void ResetPaddleAndPowerUp()
    {
        transform.position = new Vector2(0, -4.5f);
        currentPowerUp?.Reset();
    }
}
