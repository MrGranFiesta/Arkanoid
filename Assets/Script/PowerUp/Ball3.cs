using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ball3 : MonoBehaviour, IPowerUpType
{
    public void Apply(Paddle paddle)
    {
        GameObject ballPrefab = Resources.Load<GameObject>(Prefab.Ball);
        CreateBallAndImpulse(3, 3);
        CreateBallAndImpulse(Random.Range(0.2f, -0.2f), 3);
        CreateBallAndImpulse(-3, 3);
    }

    public void CreateBallAndImpulse(float x, float y)
    {
        GameObject ballPrefab = Resources.Load<GameObject>("Ball");
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D transformBall1 = ball.GetComponent<Rigidbody2D>();
        transformBall1.velocity = new Vector2(x, y);

    }
}
