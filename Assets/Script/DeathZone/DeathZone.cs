using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Ball started;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
        GameObject[] balls = GameObject.FindGameObjectsWithTag(Tag.Ball);

        if (collision.CompareTag(Tag.Ball) && balls.Length == 1)
        {
            started.Reset();
            Destroy(balls[0]);
            paddle.GetComponent<Paddle>()?.ResetPaddleAndPowerUp();

            GameObject[] powerUpList = GameObject.FindGameObjectsWithTag(Tag.PowerUp);
            foreach (var item in powerUpList)
            {
                Destroy(item);
            }
            MainClass.getGameManager().minusLife();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
