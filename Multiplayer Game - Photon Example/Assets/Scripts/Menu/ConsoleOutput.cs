using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleOutput : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Start() => textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

    public void SetText(string text, float time = 0f)
    {
        StartCoroutine(CoSetText(text, time));
    }

    private IEnumerator CoSetText(string text, float time)
    {
        textMeshPro.text = text;
        if (time > 0)
        {
            yield return new WaitForSeconds(time);
            textMeshPro.text = "";
        }
    }
}
