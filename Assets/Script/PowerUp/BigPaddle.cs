using System.Collections;
using UnityEngine;

public class BigPaddle : MonoBehaviour, IPowerUpType
{
    private Vector3 scaleOrigin = new Vector3(2, 0.5f, 1);
    
    public void Apply(Paddle paddle)
    {
        paddle.StartPowerUp(ApplyPaddle());
    }

    private IEnumerator ApplyPaddle()
    {
        GameObject Paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);

        Vector3 scaleOrigin = Paddle.transform.localScale;
        Vector3 scaleTransformed = scaleOrigin;
        scaleTransformed.x = 4f;

        Paddle.transform.localScale = scaleTransformed;
        yield return new WaitForSeconds(5f);
        this.Reset();
    }

    public void Reset()
    {
        GameObject Paddle = GameObject.FindGameObjectWithTag(Tag.Paddle);
        Paddle.transform.localScale = scaleOrigin;
    }
}
