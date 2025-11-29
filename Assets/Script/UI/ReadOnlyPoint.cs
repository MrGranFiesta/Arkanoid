using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ReadOnlyPoint : MonoBehaviour
{
    private void Awake()
    {
        //Inicializa texto
        GetComponent<TextMeshProUGUI>().text = GameManager.Point.ToString();       
    }
}
