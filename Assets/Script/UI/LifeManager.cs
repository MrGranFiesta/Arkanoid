using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifeManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //Crea escuchador de eventos
        GameManager.OnLifeChanged.AddListener(UpdateText);
        //Inicializa
        _text.text = GameManager.Life.ToString();
    }

    public void UpdateText(int text)
    {
        _text.text = text.ToString();
    }
}
