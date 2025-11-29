using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ReadOnlyTime : MonoBehaviour
{
    private void Awake()
    {
        //Inicializa y formatea texto
        GetComponent<TextMeshProUGUI>().text = TimeUtils.FormatedTime(GameManager.Time);       
    }
}
