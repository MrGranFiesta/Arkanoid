using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelUiManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //Crea escuchador de eventos
        GameManager.Instance.EventManager.OnLevelChanged.AddListener(UpdateText);
        //Inicializa
        _text.text = GameManager.Instance.Player.Level.ToString();
    }

    public void UpdateText(int text)
    {
        _text.text = text.ToString();
    }
}
