using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class Paddle : MonoBehaviour
{
    private IPowerUpType currentPowerUp;

    public void StartPowerUp(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.PowerUp))
        {
            currentPowerUp = collision.gameObject.GetComponent<IPowerUpType>();
            currentPowerUp.Apply(this);
            
            Destroy(collision.gameObject);
        }
    }

    public void ResetPaddleAndPowerUp()
    {
        transform.position = new Vector2(0, -4.5f);
        currentPowerUp?.Reset();
    }
}
