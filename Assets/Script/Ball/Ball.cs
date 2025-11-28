using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private StartedType type;
    //private static bool isStartParty = false;

    /*public bool IsStartParty
    {
        get { return isStartParty; }
        set { isStartParty = value; }
    }*/

    private void Awake()
    {
        Rigidbody2D ballRigidbody2D = GetComponent<Rigidbody2D>();

        if (StartedType.Auto == type)
        {
            Vector2 vector = new Vector2();
            vector.x = Random.Range(-3, 3);
            vector.y = 3;
            ballRigidbody2D.AddForce(vector, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        this.startedParty();
        this.FixedLoopBallInWall();
    }

    public void startedParty()
    {
        Rigidbody2D ballRigidbody2D = GetComponent<Rigidbody2D>();
        bool isPressSpace = Input.GetKey(KeyCode.Space);

        if (isPressSpace && !GameManager.IsStartParty)
        {
            Vector2 vector = new Vector2(3, 3);

            ballRigidbody2D.AddForce(vector, ForceMode2D.Impulse);
            GameManager.IsStartParty = true;
        }
    }
    public void FixedLoopBallInWall()
    {
        Rigidbody2D ballRigidbody2D = GetComponent<Rigidbody2D>();

        //Paredes laterales
        if (GameManager.IsStartParty && Mathf.Abs(ballRigidbody2D.velocity.x) < 0.1f)
        {
            float v = ballRigidbody2D.velocity.magnitude;
            if (ballRigidbody2D.transform.position.x < 0)
            {
                ballRigidbody2D.velocity = new Vector2(-3, 3).normalized * v;
            }
            else
            {
                ballRigidbody2D.velocity = new Vector2(3, 3).normalized * v;
            }
        }

        //Pared superior
        if (GameManager.IsStartParty && Mathf.Abs(ballRigidbody2D.velocity.y) < 0.1f)
        {
            float v = ballRigidbody2D.velocity.magnitude;
            ballRigidbody2D.velocity = new Vector2(3, -3).normalized * v;
        }
    }

    public void Reset()
    {
        GameManager.IsStartParty = false;
        GameObject prefab = Resources.Load<GameObject>(Prefab.Ball);
        Vector2 position = new Vector2(0, -4);
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }
}
