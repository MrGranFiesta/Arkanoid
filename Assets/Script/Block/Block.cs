using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] BlockData blockData;
    private SpriteRenderer spriteRenderer;
    private int life;
    private int point;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Da color al bloque
        spriteRenderer.color = blockData.color;
        //Settea datos
        life = blockData.life;
        point = blockData.point;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Al colisionar agrega puntos extras
        GameManager.AddPoint(GetExtraPointByLifeBlock());

        //Quita 1 vida al bloque
        life--;

        //Obtiene el numero de bloques
        var count = GameObject.FindGameObjectsWithTag(Tag.Block).Length;

        //Si es el ultimo bloque pasa el siguiente nivel
        if (count == 1 && life == 0) {
            GameManager.nextLevel();
        }

        //Si no tiene más vida destruye el bloque, sino reduce el color del bloque
        if (life <= 0)
        {
            DestroyBlock();
        }
        else
        {
            ReduceAlphaColor();
        }
    }

    private void DestroyBlock()
    {
        //Genera Power Up
        CheckGeneratePowerUp();

        //Obtiene puntos al destruir el bloque
        GameManager.AddPoint(point);
        Destroy(gameObject);
    }

    //Comprueba y genera un PowerUp
    private void CheckGeneratePowerUp() {
        if (isGeneratePowerUp()) {
            GetPowerUp();
        }
    }

    //Genera el powerUp
    private GameObject GetPowerUp() {
        GameObject prefab = Resources.Load<GameObject>(GetRamdomPrefab());
        return Instantiate(prefab, transform.position, Quaternion.identity);
    }

    //Devuelve aleatoriamente un power Up
    private string GetRamdomPrefab()
    {
        int randomPowerUp = Random.Range(0, 4);
        switch (randomPowerUp)
        {
            case 0:
                return Prefab.Ball;
            case 1:
                return Prefab.BigPaddle;
            case 2:
                return Prefab.Life;
            case 3:
                return Prefab.Ball3;
            default: return null;
        }
    }

    //Metodo que determina si se debe crear un powerUp
    private bool isGeneratePowerUp()
    {
        return Random.Range(0, 100) <= blockData.percentSpawnerPowerUp;
    }

    //Aplica una reducción de color al bloque
    private void ReduceAlphaColor()
    {
        Color c = spriteRenderer.color;
        c.a -= 0.2f;
        c.a = Mathf.Clamp01(c.a);
        spriteRenderer.color = c;
    }

    private int GetExtraPointByLifeBlock()
    {
        switch (life)
        {
            case 0: return 10;
            case 1: return 20;
            case 2: return 30;
            case 3: return 50;
            default: return 10;
        }
    }
}
