using System.Collections;
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
        _text.text = TimeUtils.FormatedTime(GameManager.Instance.Player.Time);
        StartCoroutine(UpdateCrono());
    }

    private IEnumerator UpdateCrono()
    {
        while (true)
        {
            if (GameManager.Instance.Player.IsStartParty)
            {
                GameManager.Instance.Player.Time += Time.deltaTime;
                //Da formato
                _text.text = TimeUtils.FormatedTime(GameManager.Instance.Player.Time);
            }
            yield return null;
        }
    }
}
