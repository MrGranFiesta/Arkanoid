using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private StartedType type;
    private Rigidbody2D ballRigidbody2D;

    private void Awake()
    {
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
            ballRigidbody2D.AddForce(vector, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        StartedParty();
        FixedLoopBallInWall();
    }

    //Metodo para iniciar la bola cuando se pulsa espacio
    public void StartedParty()
    {
        bool isPressSpace = Input.GetKey(KeyCode.Space);

        if (isPressSpace && !GameManager.IsStartParty)
        {
            Vector2 vector = new Vector2(3, 3);

            ballRigidbody2D.AddForce(vector, ForceMode2D.Impulse);
            GameManager.IsStartParty = true;
        }
    }

    //Soluciona el bug que se queda la bola en el techo o paredes lateral
    public void FixedLoopBallInWall()
    {
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
        //Pone en pause la bola
        GameManager.IsStartParty = false;
        
        //Genera una nueva bola en su posicion original
        GameObject prefab = Resources.Load<GameObject>(Prefab.Ball);
        Vector2 position = new Vector2(0, -4);
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        //Destrye la bola actual
        Destroy(this);
    }
}
