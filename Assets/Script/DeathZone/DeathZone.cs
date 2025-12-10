using UnityEngine;

public class DeathZone : MonoBehaviour
{
    GameObject paddle;

    public void Awake()
    {
        paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int balls = GameManager.Instance.Player.GetBallsCache();

        //Si es una bola y es la ultima resta una vida y resetea el set. Sino destruye lo que caiga
        if (collision.CompareTag(Tag.Ball) && balls == 1)
        {
            //Resetea la bola
            collision.GetComponent<Ball>()?.Reset();
            
            //Resetea la pala y sus PowersUp
            paddle.GetComponent<Paddle>()?.ResetPaddleAndPowerUp();

            //Elimina todos los powersUps que estan cayendo
            GameObject[] powerUpList = GameObject.FindGameObjectsWithTag(Tag.PowerUp);
            foreach (var item in powerUpList)
            {
                Destroy(item.gameObject);
            }

            //Resta una vida
            GameManager.Instance.AudioManager.PlaySound(Resources.Load<AudioClip>("Sounds/Damage"));
            GameManager.Instance.Player.MinusLife();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
