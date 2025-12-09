using UnityEngine;

public class Navegation : MonoBehaviour
{
    [SerializeField] private GameObject WallLeft;
    [SerializeField] private GameObject WallRight;

    private float timeVelocity = 10f;
    //TODO HACE FALTA MOVIFICAR CUANDO LA PALA ES ESALADA
    private float limitLeft;
    private float limitRight;

    public void Awake()
    {
        UpdateLimit();
    }

    void Update()
    {
        //Si el jugador no ha lanzado la bola no puede mover la pala
        if (GameManager.Instance.Player.IsStartParty)
        {
            MovePaddle();
        }
    }

    public void UpdateLimit() {
        limitLeft = GetLimitLeft();
        limitRight = GetLimitRight();
    }


    private void MovePaddle()
    {
        //Obtiene el movimiento horizontal del jugador
        float move = Input.GetAxisRaw(AxisUtils.Horizontal);
    
        float positionX = transform.position.x;
        positionX += (move * timeVelocity * Time.deltaTime);
        positionX = Mathf.Clamp(positionX, limitLeft, limitRight);
        
        //Mueve la posicion de la pala
        transform.position = new Vector3(positionX, transform.position.y);
    }

    private float GetLimitLeft()
    {
        return (transform.localScale.x / 2) + WallLeft.transform.position.x + (WallLeft.transform.localScale.x / 2);

    }

    private float GetLimitRight()
    {
        return - (transform.localScale.x / 2) + WallRight.transform.position.x - (WallRight.transform.localScale.x / 2);
    }
}
