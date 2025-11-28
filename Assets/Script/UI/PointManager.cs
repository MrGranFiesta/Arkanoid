using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PointManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        GameManager.OnPointChanged.AddListener(UpdateText);
        _text.text = MainClass.getGameManager().Point.ToString();
    }

    public void UpdateText(int text)
    {
        this._text.text = text.ToString();
    }
}
