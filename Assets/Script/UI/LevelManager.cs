using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //Crea escuchador de eventos
        GameManager.OnLevelChanged.AddListener(UpdateText);
        //Inicializa
        _text.text = GameManager.Level.ToString();
    }

    public void UpdateText(int text)
    {
        _text.text = text.ToString();
    }
}
