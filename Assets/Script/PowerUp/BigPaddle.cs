using System.Collections;
using UnityEngine;

//Hace que la pala sea mas grande
public class BigPaddle : MonoBehaviour, IPowerUpType
{   
    //Aplica el powerUp
    public void Apply(Paddle paddle)
    {
        GameManager.Instance.AudioManager.PlaySound(Resources.Load<AudioClip>("Sounds/PowerUp"));
        paddle.StartPowerUp(ApplyPaddle(paddle));
    }

    //Ejecita una corrutina para controlar el tiempo
    private IEnumerator ApplyPaddle(Paddle paddle)
    {
        //Escala la pala
        paddle.transform.localScale = GameConstants.ScalePaddleBig;
        paddle.GetComponent<Navegation>()?.UpdateLimit();
        //La deja asi 5 seg
        yield return new WaitForSeconds(5f);
        //Resetea la pala
        Reset();
    }


    public void Reset()
    {
        GameObject paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
        paddle.transform.localScale = GameConstants.ScalePaddle;
        paddle.GetComponent<Navegation>()?.UpdateLimit();
    }
}
