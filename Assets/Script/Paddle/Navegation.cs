using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navegation : MonoBehaviour
{
    [SerializeField] private GameObject WallLeftObj;
    [SerializeField] private GameObject WallRightObj;
    private Wall WallLeft;
    private Wall WallRight;

    [SerializeField] private Ball started;

    private void Awake()
    {
        WallLeft = WallLeftObj.GetComponent<Wall>();
        WallRight = WallRightObj.GetComponent<Wall>();
    }

    private float timeVelocity = 10f;

    void Update()
    {
        if (GameManager.IsStartParty)
        {
            MovePaddle();
        }
    }

    private void MovePaddle()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 vectorHorizontal = new Vector3();
        vectorHorizontal.y = 0;
        vectorHorizontal.x = inputHorizontal * this.timeVelocity * Time.deltaTime;
        this.transform.Translate(vectorHorizontal);
    
        float positionX = this.transform.position.x;
        float limitLeft = (this.transform.localScale.x / 2) + WallLeft.getPositionX() + (WallLeft.getScaleX() / 2);
        float limitRight = - (this.transform.localScale.x / 2) + WallRight.getPositionX() - (WallRight.getScaleX() / 2);
        positionX = Mathf.Clamp(positionX, limitLeft, limitRight);
        this.transform.position = new Vector3(positionX, this.transform.position.y);
    }
}
