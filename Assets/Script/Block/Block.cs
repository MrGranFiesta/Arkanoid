using System.Collections;
using System.Collections.Generic;
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
        spriteRenderer.color = blockData.color;
        
        life = blockData.life;
        point = blockData.point;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        MainClass.getGameManager().AddPoint(this.GetExtraPointByLifeBlock());

        life--;
        var count = GameObject.FindGameObjectsWithTag(Tag.Block).Length;
        Debug.Log(count);
        if (count == 1 && life == 0) {
            MainClass.getGameManager().nextLevel();
        }

        if (life <= 0)
        {
            IPowerUpType powerUp = this.GeneratePowerUp();
            if (powerUp != null)
            {
                Instantiate(PowerUpManager.GetPrefab(powerUp), transform.position, Quaternion.identity);
            }
            MainClass.getGameManager().AddPoint(point);
            Destroy(gameObject);
        }
        else
        {
            Color c = spriteRenderer.color;
            c.a -= 0.2f;
            c.a = Mathf.Clamp01(c.a);
            spriteRenderer.color = c;
        }
    }

    public int GetExtraPointByLifeBlock() {
        switch (life)
        {
            case 0: return 10;
            case 1: return 20;
            case 2: return 30;
            case 3: return 50;
            default: return 10;
        }
    }

    private IPowerUpType GeneratePowerUp() {
        int value = Random.Range(0, 100);
        if (value <= blockData.percentSpawnerPowerUp) {
            int randomPowerUp = Random.Range(0, 4);
            GameObject powerUpObject = new GameObject("PowerUp");
            switch (randomPowerUp)
            {
                case 0: return powerUpObject.AddComponent<Life>();
                case 1: return powerUpObject.AddComponent<Ball1>();
                case 2: return powerUpObject.AddComponent<Ball3>();
                case 3: return powerUpObject.AddComponent<BigPaddle>();
            }
        }

        return null;
    }
}
