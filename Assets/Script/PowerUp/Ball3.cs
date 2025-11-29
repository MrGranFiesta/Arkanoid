using UnityEngine;

//Genera 3 bolas cuando choca con la pala
public class Ball3 : MonoBehaviour, IPowerUpType
{
    public void Apply(Paddle paddle)
    {
        //Crea 3 bolas en 3 direcciones
        CreateBallAndImpulse(3, 3);
        CreateBallAndImpulse(Random.Range(0.2f, -0.2f), 3);
        CreateBallAndImpulse(-3, 3);
    }

    //Crea bolas y las impulsas
    public void CreateBallAndImpulse(float x, float y)
    {
        GameObject ballPrefab = Resources.Load<GameObject>(Prefab.Ball);
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D transformBall = ball.GetComponent<Rigidbody2D>();
        transformBall.velocity = new Vector2(x, y);
    }
}
