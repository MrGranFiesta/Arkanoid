using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        GameManager.OnLevelChanged.AddListener(UpdateText);
        _text.text = MainClass.getGameManager().Level.ToString();
    }

    public void UpdateText(int text)
    {
        this._text.text = text.ToString();
    }
}
