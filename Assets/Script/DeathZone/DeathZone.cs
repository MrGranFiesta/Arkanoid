using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
        GameObject[] balls = GameObject.FindGameObjectsWithTag(Tag.Ball);

        //Si es una bola y es la ultima resta una vida y resetea el set. Sino destruye lo que caiga
        if (collision.CompareTag(Tag.Ball) && balls.Length == 1)
        {
            //Resetea la bola
            balls[0].GetComponent<Ball>().Reset();
            
            //Resetea la pala y sus PowersUp
            paddle.GetComponent<Paddle>()?.ResetPaddleAndPowerUp();

            //Elimina todos los powersUps que estan cayendo
            GameObject[] powerUpList = GameObject.FindGameObjectsWithTag(Tag.PowerUp);
            foreach (var item in powerUpList)
            {
                Destroy(item);
            }
            
            //Resta una vida
            GameManager.minusLife();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
