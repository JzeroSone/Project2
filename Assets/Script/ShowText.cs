using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(string value)
    {
        textMeshPro.text = value;
    }
}
