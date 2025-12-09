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
        GameManager.Instance.Player.RegisterBlock();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = blockData.color;
        life = blockData.life;
        point = blockData.point;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Al colisionar agrega puntos extras
        GameManager.Instance.Player.AddPoint(GetExtraPointByLifeBlock());

        //Quita 1 vida al bloque
        life--;

        if (life > 0)
        {
            ReduceAlphaColor();
        }
        else
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        GameManager.Instance.Player.DeleteBlock();
        
        //Genera Power Up
        CheckGeneratePowerUp();

        //Obtiene puntos al destruir el bloque
        GameManager.Instance.Player.AddPoint(point);
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
        string namePrefab = PowerUpManager.GetRamdomPrefab();

            GameObject prefab = Resources.Load<GameObject>(namePrefab);
            return Instantiate(prefab, transform.position, Quaternion.identity);
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
