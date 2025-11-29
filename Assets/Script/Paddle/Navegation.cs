using UnityEngine;

public class Navegation : MonoBehaviour
{
    [SerializeField] private GameObject WallLeftObj;
    [SerializeField] private GameObject WallRightObj;
    private Wall WallLeft;
    private Wall WallRight;
    private float timeVelocity = 10f;

    private void Awake()
    {
        WallLeft = WallLeftObj.GetComponent<Wall>();
        WallRight = WallRightObj.GetComponent<Wall>();
    }

    void Update()
    {
        //Si el jugador no ha lanzado la bola no puede mover la pala
        if (GameManager.IsStartParty)
        {
            MovePaddle();
        }
    }

    private void MovePaddle()
    {
        //Obtiene el movimiento horizontal del jugador
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        //Calcula el movimeinto horizontal del jugador
        Vector3 vectorHorizontal = new Vector3();
        vectorHorizontal.y = 0;
        vectorHorizontal.x = inputHorizontal * timeVelocity * Time.deltaTime;
        transform.Translate(vectorHorizontal);
    
        float positionX = transform.position.x;
        //Calcula los limites
        float limitLeft = (transform.localScale.x / 2) + WallLeft.getPositionX() + (WallLeft.getScaleX() / 2);
        float limitRight = - (transform.localScale.x / 2) + WallRight.getPositionX() - (WallRight.getScaleX() / 2);
        positionX = Mathf.Clamp(positionX, limitLeft, limitRight);
        
        //Mueve la posicion de la pala
        transform.position = new Vector3(positionX, transform.position.y);
    }
}
