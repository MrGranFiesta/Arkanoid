using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CronoManager : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //Inicializa
        _text.text = GameManager.Time.ToString();
    }

    void Update()
    {
        UpdateCrono();
    }

    //Actualiza el cronometro
    private void UpdateCrono()
    {
        GameManager.Time += Time.deltaTime;
        //Da formato
        _text.text = TimeUtils.FormatedTime(GameManager.Time);
    }
}
