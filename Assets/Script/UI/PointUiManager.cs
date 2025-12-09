using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PointManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //Crea escuchador de eventos
        GameManager.Instance.EventManager.OnPointChanged.AddListener(UpdateText);
        //Inicializa
        _text.text = GameManager.Instance.Player.Point.ToString();
    }

    public void UpdateText(int text)
    {
        _text.text = text.ToString();
    }
}
