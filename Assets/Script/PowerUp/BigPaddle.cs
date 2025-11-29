using System.Collections;
using UnityEngine;

//Hace que la pala sea mas grande
public class BigPaddle : MonoBehaviour, IPowerUpType
{
    private Vector3 scaleOrigin = new Vector3(2, 0.5f, 1);
    
    //Aplica el powerUp
    public void Apply(Paddle paddle)
    {
        //Lo ejecuta la pala para que cuando sea destruido el power up lo pueda seguir ejecutando
        paddle.StartPowerUp(ApplyPaddle());
    }

    //Ejecita una corrutina para controlar el tiempo
    private IEnumerator ApplyPaddle()
    {
        GameObject Paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);

        //Escala la pala
        Vector3 scaleOrigin = Paddle.transform.localScale;
        Vector3 scaleTransformed = scaleOrigin;
        scaleTransformed.x = 4f;

        Paddle.transform.localScale = scaleTransformed;
        //La deja asi 5 seg
        yield return new WaitForSeconds(5f);
        //Resetea la pala
        Reset();
    }


    public void Reset()
    {
        GameObject Paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
        Paddle.transform.localScale = scaleOrigin;
    }
}
