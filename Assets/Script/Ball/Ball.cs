using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private StartedType type;
    private Rigidbody2D ballRigidbody2D;

    private void Awake()
    {
        GameManager.Instance.Player.RegisterBall();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        ImpulseBallStart();
    }

    //Metodo para impulsar la bola si esta en modo Autoimpulsada
    private void ImpulseBallStart()
    {
        if (StartedType.Auto == type)
        {
            Vector2 vector = new Vector2();
            vector.x = Random.Range(-3, 3);
            vector.y = 3;
            ballRigidbody2D.velocity = vector.normalized * GameConstants.SpeedBall;
        }
    }

    void Update()
    {
        StartedParty();
    }

    //Metodo para iniciar la bola cuando se pulsa espacio
    public void StartedParty()
    {
        bool isPressSpace = Input.GetKey(KeyCode.Space);

        if (isPressSpace && !GameManager.Instance.Player.IsStartParty)
        {
            Vector2 vector = new Vector2(3, 3);
            ballRigidbody2D.velocity = vector.normalized * GameConstants.SpeedBall;
            GameManager.Instance.Player.IsStartParty = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        FixedLoopBallInWall();
        GameManager.Instance.AudioManager.PlaySound(Resources.Load<AudioClip>("Sounds/Ball"));
    }

    //Soluciona el bug que se queda la bola en el techo o paredes lateral
    public void FixedLoopBallInWall()
    {
        //Paredes laterales
        if (GameManager.Instance.Player.IsStartParty && Mathf.Abs(ballRigidbody2D.velocity.x) < 0.1f)
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
        if (GameManager.Instance.Player.IsStartParty && Mathf.Abs(ballRigidbody2D.velocity.y) < 0.1f)
        {
            float v = ballRigidbody2D.velocity.magnitude;
            ballRigidbody2D.velocity = new Vector2(3, -3).normalized * v;
        }
    }

    public void Reset()
    {
        GameManager.Instance.Player.IsStartParty = false;

        ballRigidbody2D.velocity = Vector2.zero;
        transform.position = GameConstants.PositionBallOrigin;
    }

    public void OnDestroy()
    {
        GameManager.Instance.Player.DeleteBall();
    }
}
